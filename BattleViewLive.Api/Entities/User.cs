using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BattleViewLive.Api.Entities;

public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public string? ModifiedBy { get; set; }
}
