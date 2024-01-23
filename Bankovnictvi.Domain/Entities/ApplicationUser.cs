using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Bankovnictvi.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    [Required]
    [EmailAddress]
    public override string UserName { get; set; }
}