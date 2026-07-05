using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Skeletix.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    // =========================
    // QUICK RESULT (LATEST FILE)
    // =========================
    [HttpGet("quick-result")]
    public async Task<IActionResult> GetQuickResult(CancellationToken cancellationToken)
    {
        try
        {
            var patientId = GetPatientId();

            var result = await _reportService
                .GetQuickResultAsync(patientId, cancellationToken);

            return Ok(new
            {
                message = "Quick result retrieved successfully",
                data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = ex.Message
            });
        }
    }

    // =========================
    // DASHBOARD
    // =========================
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard(CancellationToken cancellationToken)
    {
        try
        {
            var patientId = GetPatientId();

            var stats = await _reportService
                .GetDashboardStatsAsync(patientId, cancellationToken);

            return Ok(new
            {
                message = "Dashboard retrieved successfully",
                data = stats
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = ex.Message
            });
        }
    }

    // =========================
    // helper
    // =========================
    private int GetPatientId()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(id))
            throw new Exception("Unauthorized");

        return int.Parse(id);
    }
}