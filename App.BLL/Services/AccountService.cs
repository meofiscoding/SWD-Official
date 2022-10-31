using App.BLL.Services.Contracts;
using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class AccountService : IAccountService
    {
        //private List<User> _users;
        private readonly IAccountRepository<User> _userRepository;

        public AccountService(IAccountRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string username, string password)
        {
           
            try
            {
                var user = _userRepository.Login(username,password);
                if (user != null && user.RoleId == (int)Constant.Role.Admin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
