using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Entity;

namespace App.DAL.Repositories.Contracts
{
    public interface IAccountRepository<TModels> where TModels : class
    {
        User Login(string username, string password);
        int GetRoleByName(string role);
    }
}
