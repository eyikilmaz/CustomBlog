using Microsoft.AspNetCore.Mvc;

namespace CustomBlog.Api.WebApi.Controllers;
[Route("api/[Controller]")]
[ApiController]

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
