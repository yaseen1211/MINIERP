using System;

namespace MiniERP.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
    [Key] // Primary Key
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(255)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(20)")]
    public string Phone { get; set; }

    [Column(TypeName = "NVARCHAR(500)")]
    public string Address { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime CreatedAt { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}