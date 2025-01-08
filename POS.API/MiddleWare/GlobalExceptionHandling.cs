using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace POS.API.MiddleWare
{
    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandling(RequestDelegate next) {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        public async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var errorresponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Unexpected error"
            };
            Console.WriteLine(errorresponse);
            await context.Response.WriteAsJsonAsync(errorresponse);
        }
    }
}
