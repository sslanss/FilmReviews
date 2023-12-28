﻿using Duende.IdentityServer.Models;
using FilmReviews.BL.Auth.Entities;
using FilmReviews.DataAccess.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Auth
{
    public class AuthProvider(SignInManager<UserEntity> signInManager,
    UserManager<UserEntity> userManager,
    IHttpClientFactory httpClientFactory,
    string identityServerUri,
    string clientId,
    string clientSecret) : IAuthProvider
    {
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly string _identityServerUri = identityServerUri;
        private readonly string _cliendId = clientId;
        private readonly string _clientSecret = clientSecret;

        public async Task<TokensResponse> AuthorizeUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException("Пользователь не найден.");
            var verificationPasswordResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!verificationPasswordResult.Succeeded)
            {
                throw new LoginOrPasswordInIncorrectException("Логин или пароль неверный.");
            }

            var client = _httpClientFactory.CreateClient();
            var discoveryDoc = await client.GetDiscoveryDocumentAsync(_identityServerUri);

            if (discoveryDoc.IsError)
            {
                throw new DiscoveryDocumentException("Ошибка при получении Discovery Document.");
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = discoveryDoc.TokenEndpoint,
                GrantType = GrantType.ResourceOwnerPassword,
                ClientId = _cliendId,
                ClientSecret = _clientSecret,
                UserName = user.Name,
                Password = password,
                Scope = "api offline_access"
            });

            if (tokenResponse.IsError)
            {
                throw new TokenRequestException("Ошибка при запросе токена.");
            }

            return new TokensResponse()
            {
                AccessToken = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken
            };
        }

        public async Task RegisterUser(string name, string surname, string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                throw new UserCreationException("Пользователь уже существует.");
            }

            UserEntity user = new()
            {
                Name = name,
                Surname = surname,
                Email = email,
                IsAdmin = false
            };

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);

            var createUserResult = await _userManager.CreateAsync(user);

            if (!createUserResult.Succeeded)
            {
                throw new UserCreationException("Ошибка при создании пользователя.");
            }
        }
    }
}
