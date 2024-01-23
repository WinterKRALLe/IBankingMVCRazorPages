using Bankovnictvi.Application.Abstraction;
using Bankovnictvi.Application.ViewModels;
using Bankovnictvi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Bankovnictvi.Application.Implementation;

public class IdentityService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : IIdentityService
{
    public async Task<bool> RegisterUserAsync(RegisterViewModel model)
    {
        ApplicationUser user = new()
        {
            UserName = model.UserName,
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded) return true;
        foreach (IdentityError error in result.Errors)
            Console.WriteLine($"Oops! {error.Description} {error.Code}");

        return false;
    }
    
    public async Task<(bool Success, string ErrorMessage)> LoginUserAsync(LoginViewModel model)
    {
        var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);

        if (result.Succeeded)
        {
            return (true, string.Empty);
        }

        if (result.RequiresTwoFactor)
        {
            return (false, "requiresTwoFactor");
        }

        if (result.IsLockedOut)
        {
            return (false, "locked");
        }

        if (result.IsNotAllowed)
        {
            return (false, "notAllowed");
        }

        return (false, "Invalid username or password");
    }
    
    public async Task<bool> LogoutUserAsync()
    {
        // var user = httpContext.User;

        // if (!signInManager.IsSignedIn(user)) return false;
        await signInManager.SignOutAsync();
        return true;
    }
}