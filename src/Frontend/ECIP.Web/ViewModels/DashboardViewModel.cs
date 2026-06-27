using ECIP.Shared.DTOs;

namespace ECIP.Web.ViewModels;

/// <summary>
/// View model for the Dashboard page.
/// </summary>
public class DashboardViewModel
{
    /// <summary>
    /// Gets or sets the health status of the API.
    /// </summary>
    public string HealthStatus { get; set; } = "Offline";

    /// <summary>
    /// Gets or sets the application version.
    /// </summary>
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the target framework.
    /// </summary>
    public string Framework { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the health response details.
    /// </summary>
    public HealthResponse? HealthResponse { get; set; }

    /// <summary>
    /// Gets or sets the version response details.
    /// </summary>
    public VersionResponse? VersionResponse { get; set; }

    /// <summary>
    /// Gets or sets the system status response details.
    /// </summary>
    public SystemStatusResponse? SystemStatus { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the dashboard is loaded.
    /// </summary>
    public bool IsLoaded { get; set; }
}
