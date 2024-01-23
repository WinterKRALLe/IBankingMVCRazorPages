using Bankovnictvi.Application.Abstraction;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bankovnictvi.Areas.Identity.Pages.Account;

public class LogoutModel(IIdentityService identityService) : PageModel
{

    public async Task<IActionResult> OnPostAsync()
    {
        var result = await identityService.LogoutUserAsync();
        if (result) return RedirectToPage("/Account/Login");
        return Page();
    }
}