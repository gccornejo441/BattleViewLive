using BattleViewLive.Api.Entities;

namespace BattleViewLive.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> RegisterUserAsync(RegisterUser user);
        Task<List<User>> GetUserList();
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int key);
    }
}
