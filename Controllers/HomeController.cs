using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyECommerceApp.Models;

namespace MyECommerceApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
{
    var errorViewModel = new ErrorViewModel
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
        ErrorMessage = "An unexpected error occurred."
    };
    return View(errorViewModel);
}

}
