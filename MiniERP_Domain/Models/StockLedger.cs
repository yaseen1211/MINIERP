using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniERP.Models;

public class StockLedger
{
    [Key] // Primary Key
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Column(TypeName = "INT")]
    public int QuantityIn { get; set; }

    [Column(TypeName = "INT")]
    public int QuantityOut { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public string ReferenceType { get; set; } // e.g., Sale, Purchase, Adjustment

    public int ReferenceId { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime CreatedAt { get; set; }

    // Navigation
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}
