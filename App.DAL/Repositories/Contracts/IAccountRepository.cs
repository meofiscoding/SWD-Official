using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Models;

namespace App.DAL.Repositories.Contracts
{
    public interface IAccountRepository<TModels> where TModels : class
    {
        User Login(string username, string password);
    }
}
