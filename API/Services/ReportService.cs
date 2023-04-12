using skibd.API.Models;

namespace skibd.API.Services;

public class ReportService : IReportService
{
    private readonly string pathToReports = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Reports");

    public List<Report> Reports => Directory.GetFiles(pathToReports).Select(path => new Report(path)).ToList(); 
}
