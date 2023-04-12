using skibd.API.Models;

namespace skibd.API.Services;

public interface IReportService
{
    public List<Report> Reports { get; }
}
