using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Skeletix.Services.DashboardService;

namespace Skeletix.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // 🔐 لازم Login
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    // ============================
    // Get Dashboard for Logged User
    // ============================
    [HttpGet]
    public async Task<IActionResult> GetDashboard(CancellationToken cancellationToken)
    {
        try
        {
            var patientIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(patientIdClaim))
            {
                return Unauthorized(new
                {
                    message = "User not authenticated"
                });
            }

            int patientId = int.Parse(patientIdClaim);

            var result = await _dashboardService.GetStatsAsync(patientId, cancellationToken);

            return Ok(new
            {
                message = "Dashboard retrieved successfully",
                data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Internal server error",
                error = ex.Message
            });
        }
    }
}