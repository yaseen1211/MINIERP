using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiniERP.Models;

public class Role
{
    [Key] // Primary Key
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(100)")]
    public string Name { get; set; }

    // Navigation property
    public ICollection<User> Users { get; set; } = new List<User>();
}
