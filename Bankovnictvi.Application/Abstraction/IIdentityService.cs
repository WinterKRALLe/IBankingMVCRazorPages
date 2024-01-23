using Bankovnictvi.Application.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Bankovnictvi.Application.Abstraction;

public interface IIdentityService
{
    Task<bool> RegisterUserAsync(RegisterViewModel model);
    Task<(bool Success, string ErrorMessage)> LoginUserAsync(LoginViewModel model);
    Task<bool> LogoutUserAsync();
}