using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Azure.Functions.Worker;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http.Features;

public class AuthenticationMiddleware : IFunctionsWorkerMiddleware
{
    private readonly TokenValidationParameters _tokenValidationParameters;

    public AuthenticationMiddleware(TokenValidationParameters tokenValidationParameters)
    {
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var httpRequestData = await context.GetHttpRequestDataAsync();
        if (httpRequestData == null)
        {
            SetHttpResponseStatusCode(context, HttpStatusCode.BadRequest);
            return;
        }

        if (!httpRequestData.Headers.TryGetValues("Authorization", out var authHeaders) || !authHeaders.Any())
        {
            SetHttpResponseStatusCode(context, HttpStatusCode.Unauthorized);
            return;
        }

        var token = authHeaders.First().Split(" ").Last();
        var tokenHandler = new JwtSecurityTokenHandler();
        ClaimsPrincipal principal;

        try
        {
            principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
        }
        catch (SecurityTokenException)
        {
            SetHttpResponseStatusCode(context, HttpStatusCode.Unauthorized);
            return;
        }

        var roles = principal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
        var functionName = context.FunctionDefinition.Name;
        var policyName = GetPolicyNameForFunction(functionName);

        if (!CheckAuthorization(policyName, roles))
        {
            SetHttpResponseStatusCode(context, HttpStatusCode.Forbidden);
            return;
        }

        await next(context);
    }

    private string GetPolicyNameForFunction(string functionName)
    {
        if (functionName.Contains("AdminPolicy"))
        {
            return "AdminPolicy";
        }
        else
        {
            return "UserPolicy";
        }
    }

    private bool CheckAuthorization(string policyName, IList<string> roles)
    {
        if (policyName == "AdminPolicy")
        {
            return roles.Contains("Admin");
        }
        if (policyName == "UserPolicy")
        {
            return roles.Contains("User");
        }
        return false;
    }

    private void SetHttpResponseStatusCode(FunctionContext context, HttpStatusCode statusCode)
    {
        var httpResponseFeature = context.Features.Get<IHttpResponseFeature>();
        if (httpResponseFeature != null)
        {
            httpResponseFeature.StatusCode = (int)statusCode;
        }
    }
}
