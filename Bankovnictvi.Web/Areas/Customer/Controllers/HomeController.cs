using Microsoft.AspNetCore.Mvc;

namespace Bankovnictvi.Areas.Customer.Controllers;

public class HomeController : Controller
{
    [Area("Customer")]
    public IActionResult Index()
    {
        return View();
    }
}