﻿using CommunityToolkit.Mvvm.Messaging.Messages;
using Volo.Abp.Identity;
using Volo.Saas.Host.Dtos;

namespace Accredi.Maui.Messages;
public class IdentityUserCreateMessage : ValueChangedMessage<IdentityUserCreateDto>
{
    public IdentityUserCreateMessage(IdentityUserCreateDto value) : base(value)
    {
    }
}