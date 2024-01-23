using Bankovnictvi.Application.Abstraction;
using Bankovnictvi.Application.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bankovnictvi.Areas.Identity.Pages.Account;

public class LoginModel(IIdentityService identityService) : PageModel
{
    public async Task<IActionResult> OnGetAsync()
    {
        Model ??= new();
        
        if (HttpMethods.IsGet(HttpContext.Request.Method))
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        }

        return Page();
    }

    [BindProperty]
    public LoginViewModel Model { get; set; } = new();
    
    public async Task<IActionResult> OnPostAsync()
    {
        var (result, _) = await identityService.LoginUserAsync(Model);
        if (result) return LocalRedirect("/");

        return Page();
    }
}