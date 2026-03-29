namespace MiniERP_Application.DTOs
{
    public class ProductRequestDto
    {
        public int Mode { get; set; }
        public int? Id { get; set; }
        public string? ProductName { get; set; }
        public int StockQty { get; set; }
        public decimal Price { get; set; }
    }
}
