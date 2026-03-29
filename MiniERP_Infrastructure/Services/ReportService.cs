using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniERP_Application.Services;
using System.Data;

namespace MiniERP_Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;
        public ReportService(AppDbContext context) => _context = context;

        public async Task<object> ManageReportAsync(int mode, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var conn = _context.Database.GetDbConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "EXEC ManageReport @Mode, @FromDate, @ToDate";

                var p1 = cmd.CreateParameter(); p1.ParameterName = "@Mode"; p1.Value = mode; cmd.Parameters.Add(p1);
                var p2 = cmd.CreateParameter(); p2.ParameterName = "@FromDate"; p2.Value = (object?)fromDate ?? DBNull.Value; cmd.Parameters.Add(p2);
                var p3 = cmd.CreateParameter(); p3.ParameterName = "@ToDate"; p3.Value = (object?)toDate ?? DBNull.Value; cmd.Parameters.Add(p3);

                using var reader = await cmd.ExecuteReaderAsync();
                var results = new List<Dictionary<string, object>>();

                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                    results.Add(row);
                }

                return new { Success = true, Message = "Report fetched successfully", Data = results };
            }
            catch (Exception ex)
            {
                return new { Success = false, Message = ex.Message, Data = (object)null };
            }
            finally
            {
                await conn.CloseAsync();
            }
        }
    }
}
