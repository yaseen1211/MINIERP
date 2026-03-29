namespace MiniERP_Application.DTOs
{
    public class SaleItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class CreateSaleDto
    {
        public int CustomerId { get; set; }
        public int CreatedBy { get; set; }
        public List<SaleItemDto> Items { get; set; }
    }
}
