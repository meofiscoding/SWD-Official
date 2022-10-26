using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Models;

namespace App.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TModels> where TModels : class
    {
        Task<List<TModels>> GetCards();
        User Login(string username, string password);
    }
}
