namespace BattleViewLive.Api.Entities
{
    public class EditUser
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string UserRole { get; set; }
        public string Password { get; set; }

        public DateTime? Modified { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
