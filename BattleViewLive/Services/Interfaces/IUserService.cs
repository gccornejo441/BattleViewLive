using BattleViewLive.Api.Entities;

namespace BattleViewLive.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user, string updatedBy);
        Task<List<User>> GetUserList();
        Task<User> GetUserByUserNameAsync(string userName)
        {
            (string userName);
        Task<User> UpdateUser(User user, string modifiedBy);
        Task<bool> DeleteUser(int userId);
    }
}
