﻿using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.AspNetCore.Authorization;
using Accredi.Maui.Localization;
using Accredi.Maui.Messages;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace Accredi.Maui.ViewModels;

public abstract partial class AccrediViewModelBase : ObservableObject
{
    public IAbpLazyServiceProvider? LazyServiceProvider { get; set; }

    public ICurrentTenant CurrentTenant => LazyServiceProvider?.LazyGetRequiredService<ICurrentTenant>()!;

    public ICurrentUser CurrentUser => LazyServiceProvider?.LazyGetRequiredService<ICurrentUser>()!;

    public IAbpAuthorizationService AuthorizationService => LazyServiceProvider?.LazyGetRequiredService<IAbpAuthorizationService>()!;

    public LocalizationResourceManager L => LazyServiceProvider?.LazyGetRequiredService<LocalizationResourceManager>()!;

    protected void HandleException(Exception exception, [CallerMemberName] string? methodName = null)
    {
        if (Application.Current is { MainPage: { } })
        {
            Application.Current.MainPage.DisplayAlert(L["Error"].Value, exception.Message, L["OK"].Value);
        }
    }
}
