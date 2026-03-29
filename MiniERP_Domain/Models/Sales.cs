using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniERP.Models;

public class Sale
{
    [Key] // Primary Key
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Column(TypeName = "DECIMAL(10,2)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime SaleDate { get; set; }

    [Required]
    public int CreatedBy { get; set; }

    // Navigation
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }

    [ForeignKey("CreatedBy")]
    public User CreatedByUser { get; set; }

    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}