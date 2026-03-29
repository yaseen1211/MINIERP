namespace MiniERP_Application.DTOs
{
    public class ReportRequestDto
    {
        public int Mode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
