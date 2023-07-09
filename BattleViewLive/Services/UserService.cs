using BattleViewLive.Api.Entities;
using BattleViewLive.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BattleViewLive.Services
{
    public class UserService : IUserService
    {
        private readonly IDbService _dbService;
        public UserService(IDbService dbService) 
        { 
            _dbService = dbService;
        }

        public Task<bool> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUserList()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUserAsync(User user, string updatedBy)
        {
            // Set the CreatedBy and ModifiedBy values
            user.CreatedBy = updatedBy;
            user.ModifiedBy = updatedBy;

            var result = await _dbService.Insert<User>("INSERT INTO public.users (username, email, password_hash, user_role, created_by, modified_by) VALUES (@UserName, @Email, @PasswordHash, @UserRole, @CreatedBy, @ModifiedBy)", user);
            return true;

        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
