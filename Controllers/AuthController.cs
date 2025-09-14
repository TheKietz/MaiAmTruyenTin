using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    // Lấy View Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // Lấy View Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
}