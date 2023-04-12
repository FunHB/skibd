using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using skibd.API.Models;
using skibd.API.Services;

namespace skibd.Pages.Reports;

public class DetailsModel : PageModel
{
    private readonly IReportService _reportService = new ReportService();

    public Report? Report { get; set; }

    public IActionResult OnGet(int reportId)
    {
        Report = _reportService.Reports?.FirstOrDefault(Report => Report.Id == reportId);

        if (Report == null)
        {
            return NotFound();
        }

        return Page();
    }
}
