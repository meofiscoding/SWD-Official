using App.BLL.Services.Contracts;
using App.DAL.Models;
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
        private readonly IGenericRepository<User> _userRepository;

        public AccountService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string username, string password)
        {
           
            try
            {
                return _userRepository.Login(username,password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
