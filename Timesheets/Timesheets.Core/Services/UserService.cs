﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.Interfaces;
using Timesheets.Core.Responses;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Models;

namespace Timesheets.Core.Services
{
    public sealed class UserService : IUserService
    {
        public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";

        private readonly ILoginRepository _loginRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public UserService(ILoginRepository loginRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _loginRepository = loginRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<bool> CreateProfile(string username, string password, CancellationToken cts)
        {
            var profile = new Login()
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = password
            };

            return await _loginRepository.Create(profile, cts);
        }

        public async Task<bool> DeleteProfile(string username, string password, CancellationToken cts)
        {
            var profile = await _loginRepository.Read(username, cts);
            if (profile == null || profile.Password != password)
            {
                return false;
            }

            var token = await _refreshTokenRepository.Get(profile.RefreshTokenId, cts);

            if (token != null)
            {
                await _refreshTokenRepository.Remove(token.Id, cts);
            }

            return await _loginRepository.Delete(profile.Id, cts);
        }

        public async Task<TokenResponse> Authenticate(string username, string password, CancellationToken cts)
        {
            var profile = await _loginRepository.Read(username, cts);
            if (profile == null || profile.Password != password)
            {
                return null;
            }

            RefreshToken refreshToken;

            if (profile.RefreshTokenId != Guid.Empty)
            {
                refreshToken = await _refreshTokenRepository.Get(profile.RefreshTokenId, cts);
            }
            else
            {
                refreshToken = await GenerateRefreshToken(profile, cts);
            }

            if (refreshToken.IsExpired)
            {
                refreshToken = await GenerateRefreshToken(profile, cts);
            }

            return new TokenResponse()
            {
                Token = GenerateJwtToken(profile.Id.ToString(), 15),
                RefreshToken = refreshToken.Token
            };
        }

        public async Task<string> RefreshToken(string token, CancellationToken cts)
        {
            var refreshToken = await _refreshTokenRepository.Get(token, cts);
            var profile = await _loginRepository.Read(refreshToken.LoginId, cts);

            await _refreshTokenRepository.Remove(refreshToken.Id, cts);

            refreshToken = await GenerateRefreshToken(profile, cts);

            return refreshToken.Token;
        }

        private string GenerateJwtToken(string id, int minutes)
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

        private async Task<RefreshToken> GenerateRefreshToken(Login profile, CancellationToken cts)
        {
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Expires = DateTime.Now.AddMinutes(360),
                Token = GenerateJwtToken(profile.Id.ToString(), 360),
                LoginId = profile.Id
            };

            profile.RefreshTokenId = refreshToken.Id;

            await _loginRepository.Update(profile, cts);
            await _refreshTokenRepository.Add(refreshToken, cts);

            return refreshToken;
        }
    }
}
