﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Accredi.Maui.Oidc;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Volo.Abp.Threading;

namespace Accredi.Maui;

public class MauiCurrentPrincipalAccessor : CurrentPrincipalAccessorBase, ITransientDependency
{
    private readonly ILoginService _loginService;

    public MauiCurrentPrincipalAccessor(ILoginService loginService)
    {
        _loginService = loginService;
    }

    protected override ClaimsPrincipal GetClaimsPrincipal()
    {
        var tokenString = AsyncHelper.RunSync(() => _loginService.GetAccessTokenAsync());
        if (tokenString.IsNullOrWhiteSpace())
        {
            return new ClaimsPrincipal();
        }

        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
        return new ClaimsPrincipal(new ClaimsIdentity(token.Claims));
    }
}