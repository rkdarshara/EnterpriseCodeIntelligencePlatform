using Microsoft.AspNetCore.Mvc;

namespace ECIP.Web.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
