using BattleViewLive.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BattleViewLive.Authentication
{
    public class UserAccountService
    {
        private readonly BattleviewContext _battleviewContext;
        private List<User> _users;

        public UserAccountService(BattleviewContext battleviewContext)
        {
            _battleviewContext = battleviewContext;
            _users = new List<User>();
        }

        public User? GetByUserName(string userName)
        {
            var users = _battleviewContext.Users.FirstOrDefault(x => x.Username == userName);
            if (users == null)
                return null;
            return users;
        }
    }

}
