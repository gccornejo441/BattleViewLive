using BattleViewLive.Api.Entities;
using BattleViewLive.Services.Interfaces;

namespace BattleViewLive.Services
{
    public class UserService : IUserService
    {
        private readonly IDbService _dbService;
        public UserService(IDbService dbService) 
        { 
            _dbService = dbService;
        }


        public async Task<User> RegisterUserAsync(RegisterUser user)
        {
            var result = await _dbService.Insert<int>"INSERT INTO public.users (userid, username, email, password_hash, user_role, created_by, modified_by) VALUES (@UserId, @UserName, @Email, @PasswordHash, @UserRol, @CreatedBy, @ModifiedBy)", user);
            return true;
        }
        public Task<List<User>> GetUserList()
        {
            throw new NotImplementedException();
        }


        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUser(int key)
        {
            throw new NotImplementedException();
        }
    }
}
