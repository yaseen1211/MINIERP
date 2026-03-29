using System;
using System.ComponentModel.DataAnnotations;

namespace MiniERP.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Product
{
    [Key] // Primary Key
    [Column("id")]
    public int ProductId { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(255)")]
    public string ProductName { get; set; }

    [Column(TypeName = "INT")]
    public int StockQty { get; set; }

    [Column(TypeName = "DECIMAL(8,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "BIT")]
    public bool IsActive { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime CreatedAt { get; set; }

    public ICollection<SaleItem> SaleItems { get; set; }

    public ICollection<StockLedger> StockLedgers { get; set; } = new List<StockLedger>();
}

