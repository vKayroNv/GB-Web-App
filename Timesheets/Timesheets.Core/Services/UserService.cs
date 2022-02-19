using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Timesheets.Core.Interfaces;
using Timesheets.Core.Responses;
using Timesheets.Storage.Models;

namespace Timesheets.Core.Services
{
    public class UserService : IUserService
    {
        private IDictionary<string, AuthResponse> _users = new Dictionary<string, AuthResponse>()
        {
            {"test", new AuthResponse() { Password = "test"}}
        };

        public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";

        public TokenResponse Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var tokenResponse = new TokenResponse();
            int i = 0;
            foreach (KeyValuePair<string, AuthResponse> pair in _users)
            {
                i++;
                if (string.CompareOrdinal(pair.Key, user) == 0 && string.CompareOrdinal(pair.Value.Password, password) == 0)
                {
                    tokenResponse.Token = GenerateJwtToken(i, 15);
                    var refreshToken = GenerateRefreshToken(i);
                    pair.Value.LatestRefreshToken = refreshToken;
                    tokenResponse.RefreshToken = refreshToken.Token;
                    return tokenResponse;
                }

            }
            return null;
        }

        public string RefreshToken(string token)
        {
            int i = 0;
            foreach (KeyValuePair<string, AuthResponse> pair in _users)
            {
                i++;
                if (string.CompareOrdinal(pair.Value.LatestRefreshToken.Token, token) == 0
                    && pair.Value.LatestRefreshToken.IsExpired is false)
                {
                    pair.Value.LatestRefreshToken = GenerateRefreshToken(i);
                    return pair.Value.LatestRefreshToken.Token;
                }
            }
            return string.Empty;
        }

        private string GenerateJwtToken(int id, int minutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(int id)
        {
            var refreshToken = new RefreshToken
            {
                Expires = DateTime.Now.AddMinutes(360),
                Token = GenerateJwtToken(id, 360)
            };
            return refreshToken;
        }
    }
}
