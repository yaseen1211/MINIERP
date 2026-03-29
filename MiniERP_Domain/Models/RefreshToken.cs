using System;

namespace MiniERP.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RefreshToken
{
    [Key] // Primary Key
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(500)")]
    public string Token { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime ExpiryDate { get; set; }

    [Column(TypeName = "BIT")]
    public bool IsRevoked { get; set; } = false;

    // Navigation property
    [ForeignKey("UserId")]
    public User User { get; set; }
}