using MiniERP_Application.DTOs;

namespace MiniERP_Application.Services
{
    public interface IReportService
    {
        Task<object> ManageReportAsync(int mode, DateTime? fromDate = null, DateTime? toDate = null);
    }
}
