using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImperialMarmoraria.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    [Authorize]
    [HttpGet]
    public IActionResult GetPaginaHome()
    {
        return View("~/Pages/home.cshtml");
    }
}
