using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using POS.Application.Interface;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace POS.Persistance.Repository
{
    public class IssueTokenRepository : IIssueTokenRepository
    {
        private readonly IConfiguration _configuration;

        public IssueTokenRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            // Validate configuration keys
            if (string.IsNullOrEmpty(_configuration["Jwt:Key"]) ||
                string.IsNullOrEmpty(_configuration["Jwt:Issuer"]) ||
                string.IsNullOrEmpty(_configuration["Jwt:Audience"]))
            {
                throw new ArgumentException("JWT configuration is missing.");
            }
        }

        public Task<string> IssueToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()), // Standard claim for user ID
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Name), // Standard claim for username
                new Claim(ClaimTypes.Role, user.Role), // Role claim for authorization
                new Claim(JwtRegisteredClaimNames.Typ, "Bearer") // Token type
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
