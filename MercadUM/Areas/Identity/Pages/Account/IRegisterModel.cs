// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using MercadUM.Model;
using Microsoft.AspNetCore.Mvc;

namespace MercadUM.Areas.Identity.Pages.Account
{
    public interface IRegisterModel
    {

        Task OnGetAsync(string returnUrl = null);
        Task<IActionResult> OnPostAsync(string returnUrl = null);
    }
}