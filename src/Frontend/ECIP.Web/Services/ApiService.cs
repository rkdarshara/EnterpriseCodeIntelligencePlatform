using System.Text.Json;
using ECIP.Shared.DTOs;

namespace ECIP.Web.Services;

/// <summary>
/// Service for communicating with the ECIP.API backend.
/// </summary>
public interface IApiService
{
    /// <summary>
    /// Gets the health status of the API.
    /// </summary>
    Task<HealthResponse?> GetHealthAsync();

    /// <summary>
    /// Gets the version information of the API.
    /// </summary>
    Task<VersionResponse?> GetVersionAsync();

    /// <summary>
    /// Gets the system status of all services.
    /// </summary>
    Task<SystemStatusResponse?> GetSystemStatusAsync();
}

/// <summary>
/// Implementation of the API service.
/// </summary>
public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiService> _logger;
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    /// <summary>
    /// Gets the health status of the API.
    /// </summary>
    public async Task<HealthResponse?> GetHealthAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/health");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var content = JsonSerializer.Deserialize<ApiResponse<HealthResponse>>(json, JsonOptions);
                return content?.Data;
            }

            _logger.LogWarning("Health check failed with status code: {StatusCode}", response.StatusCode);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling health endpoint");
            return null;
        }
    }

    /// <summary>
    /// Gets the version information of the API.
    /// </summary>
    public async Task<VersionResponse?> GetVersionAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/version");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var content = JsonSerializer.Deserialize<ApiResponse<VersionResponse>>(json, JsonOptions);
                return content?.Data;
            }

            _logger.LogWarning("Version endpoint failed with status code: {StatusCode}", response.StatusCode);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling version endpoint");
            return null;
        }
    }

    /// <summary>
    /// Gets the system status of all services.
    /// </summary>
    public async Task<SystemStatusResponse?> GetSystemStatusAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/system");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var content = JsonSerializer.Deserialize<ApiResponse<SystemStatusResponse>>(json, JsonOptions);
                return content?.Data;
            }

            _logger.LogWarning("System status endpoint failed with status code: {StatusCode}", response.StatusCode);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling system status endpoint");
            return null;
        }
    }
}
