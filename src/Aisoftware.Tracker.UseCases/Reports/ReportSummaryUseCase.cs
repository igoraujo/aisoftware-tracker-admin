using Aisoftware.Tracker.Repositories.Base;
using Aisoftware.Tracker.UseCases.Base;
using Aisoftware.Tracker.Borders.Constants;
using Aisoftware.Tracker.Borders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aisoftware.Tracker.UseCases.Reports.UseCases;
public class ReportSummaryUseCase : IBaseReportUseCase<ReportSummary>
{
    private readonly IBaseReportRepository<ReportSummary> _repository;

    public ReportSummaryUseCase(IBaseReportRepository<ReportSummary> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ReportSummary>> FindAll(IDictionary<string, string> queryParams)
    {
        var response = await _repository.FindAll($"{Endpoints.REPORTS}/{Endpoints.SUMMARY}", queryParams);

        return response;
    }
}
