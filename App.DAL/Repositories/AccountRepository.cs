using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.DataContext;
using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories
{
    public class AccountRepository<TModel> : IAccountRepository<TModel> where TModel : class
    {

        private readonly CMCContext _cmcContext;

        public AccountRepository(CMCContext cmcContext)
        {
            _cmcContext = cmcContext;
        }

        public int GetRoleByName(string role)
        {
            //get role id by name ignore case
            return _cmcContext.Roles.Where(r => r.RoleName.ToLower() == role.ToLower()).FirstOrDefault().RoleId;
        } 

        public User Login(string username, string password)
        {
            ////return User that have username and password
            if (_cmcContext.Users.Any(p => p.Username.Equals(username)) && _cmcContext.Users.Any(p => p.Password.Equals(password)))
            {
                return _cmcContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
            else
            {
                return null;
            }
        }
    }
}
