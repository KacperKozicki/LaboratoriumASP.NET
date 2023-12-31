using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult AccessDenied(string message)
    {
        ViewBag.ErrorMessage = message;
        return View();
    }
}
