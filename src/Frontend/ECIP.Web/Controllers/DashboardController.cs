using Microsoft.AspNetCore.Mvc;
using ECIP.Web.Services;
using ECIP.Web.ViewModels;

namespace ECIP.Web.Controllers;

/// <summary>
/// Dashboard controller for the main application page.
/// </summary>
public class DashboardController : Controller
{
    private readonly IApiService _apiService;
    private readonly ILogger<DashboardController> _logger;

    public DashboardController(IApiService apiService, ILogger<DashboardController> logger)
    {
        _apiService = apiService;
        _logger = logger;
    }

    /// <summary>
    /// Gets the dashboard index page with health and version information.
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var viewModel = new DashboardViewModel();

        try
        {
            // Get health status
            var health = await _apiService.GetHealthAsync();
            if (health != null)
            {
                viewModel.HealthStatus = health.Status ?? "Offline";
                viewModel.HealthResponse = health;
            }
            else
            {
                viewModel.HealthStatus = "Offline";
            }

            // Get version information
            var version = await _apiService.GetVersionAsync();
            if (version != null)
            {
                viewModel.Version = version.Version ?? string.Empty;
                viewModel.Framework = version.Framework ?? string.Empty;
                viewModel.VersionResponse = version;
            }

            // Get system status
            var systemStatus = await _apiService.GetSystemStatusAsync();
            if (systemStatus != null)
            {
                viewModel.SystemStatus = systemStatus;
            }

            viewModel.IsLoaded = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading dashboard data");
            viewModel.HealthStatus = "Offline";
            viewModel.IsLoaded = true;
        }

        return View(viewModel);
    }
}
