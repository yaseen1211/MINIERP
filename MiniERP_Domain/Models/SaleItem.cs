using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniERP.Models;

public class SaleItem
{
    [Key] // Primary Key
    public int Id { get; set; }

    [Required]
    public int SaleId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Column(TypeName = "INT")]
    public int Quantity { get; set; }

    [Column(TypeName = "DECIMAL(8,2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal TotalPrice { get; set; }

    // Navigation
    [ForeignKey("SaleId")]
    public Sale Sale { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}