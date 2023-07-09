using BattleViewLive.Api.Entities;

namespace BattleViewLive.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user, string updatedBy);
        Task<List<User>> GetUserList();
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int userId);
    }
}
