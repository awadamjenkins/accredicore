﻿using System.ComponentModel;
using System.Globalization;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Localization;
using Accredi.Localization;
using Accredi.Maui.Messages;
using Volo.Abp.DependencyInjection;

namespace Accredi.Maui.Localization;

public class LocalizationResourceManager : INotifyPropertyChanged, ISingletonDependency
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private CultureInfo _currentCulture;
    private readonly IStringLocalizer _localizer;

    public CultureInfo CurrentCulture {
        get => _currentCulture;
        set {
            _currentCulture = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

            WeakReferenceMessenger.Default.Send(new LanguageChangedMessage(value.Name));
        }
    }

    public LocalizationResourceManager(IServiceProvider serviceProvider)
    {
        _localizer = serviceProvider.GetRequiredService<IStringLocalizerFactory>().Create(typeof(AccrediResource));
        _currentCulture = CultureInfo.CurrentCulture;
    }

    public LocalizedString this[string resourceKey] => GetValue(resourceKey);

    public LocalizedString GetValue(string resourceKey)
    {
        CultureInfo.CurrentCulture = CurrentCulture;
        CultureInfo.CurrentUICulture = CurrentCulture;

        return _localizer[resourceKey];
    }
}
