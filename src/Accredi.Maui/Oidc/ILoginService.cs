﻿using IdentityModel.OidcClient;

namespace Accredi.Maui.Oidc;

public interface ILoginService
{
    Task<LoginResult> LoginAsync();

    Task<LogoutResult> LogoutAsync();

    Task<string> GetAccessTokenAsync();

    Task<string> TryRefreshTokenAsync();
}