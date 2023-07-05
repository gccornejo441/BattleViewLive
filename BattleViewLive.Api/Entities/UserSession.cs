using System;
using System.Collections.Generic;

namespace BattleViewLive.Api.Entities;

public partial class UserSession
{
    public string Username { get; set; } = null!;

    public string UserRole { get; set; } = null!;
}
