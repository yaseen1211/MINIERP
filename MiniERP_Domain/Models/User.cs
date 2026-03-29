using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniERP.Models;

public class User
{
    [Key] // Primary Key
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(100)")]
    public string Username { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(500)")]
    public string PasswordHash { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime CreatedAt { get; set; }

    // Navigation
    [ForeignKey("RoleId")]
    public Role Role { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}