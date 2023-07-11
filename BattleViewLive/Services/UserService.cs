using BattleViewLive.Api.Entities;
using BattleViewLive.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BattleViewLive.Services
{
    public class UserService : IUserService
    {
        private readonly IDbService _dbService;
        public UserService(IDbService dbService) 
        { 
            _dbService = dbService;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var deleteuser = await _dbService.Delete<int>("DELETE FROM public.users WHERE userid =@UserId", new { userId = userId });
            return true;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var username = await _dbService.GetAsync<User>("SELECT * FROM public.users WHERE username = @UserName", new { username = userName });
            return username;
        }

        public async Task<List<User>> GetUserList()
        {
            var userList = await _dbService.GetAll<User>("SELECT * FROM public.users", new { });
            return userList;
        }

        public async Task<bool> RegisterUserAsync(User user, string updatedBy)
        {
            // Set the CreatedBy and ModifiedBy values
            user.CreatedBy = updatedBy;
            user.ModifiedBy = updatedBy;

            var result = await _dbService.Insert<User>("INSERT INTO public.users (username, email, password_hash, user_role, created_by, modified_by) VALUES (@UserName, @Email, @PasswordHash, @UserRole, @CreatedBy, @ModifiedBy)", user);
            return true;

        }

        public async Task<User> UpdateUser(User user, string modifiedBy)
        {
            user.ModifiedBy = modifiedBy;
            var updateEmployee = await _dbService.Update<int>("Update public.users SET username=@UserName, email=@Email, password_hash=@PasswordHash, modified_by=@ModifiedBy WHERE userid=@userId", user);
            return user;
        }
    }
}
