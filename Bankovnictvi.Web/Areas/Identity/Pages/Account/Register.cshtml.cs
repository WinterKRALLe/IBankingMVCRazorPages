using Bankovnictvi.Application.Abstraction;
using Bankovnictvi.Application.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bankovnictvi.Areas.Identity.Pages.Account;

public class RegisterModel(IIdentityService identityService) : PageModel
{
    public IActionResult OnGet()
    {
        Model ??= new();
        return Page();
    }
    
    [BindProperty]
    public RegisterViewModel Model { get; set; } = new();
    
    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine(Model.UserName + " " + Model.Password);
        var result = await identityService.RegisterUserAsync(Model);
        if (result) return RedirectToPage("/Account/Login");
        return Page();
    }
}