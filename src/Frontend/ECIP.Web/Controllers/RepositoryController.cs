using Microsoft.AspNetCore.Mvc;

namespace ECIP.Web.Controllers;

public class RepositoryController : Controller
{
    public IActionResult Index()
    {
        return View("_Placeholder", "Repository Manager");
    }
}
