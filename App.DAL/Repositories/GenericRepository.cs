using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.DataContext;
using App.DAL.Models;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {

        private readonly CmcContext _cmcContext;

        public GenericRepository(CmcContext cmcContext)
        {
            _cmcContext = cmcContext;
        }

        public async Task<List<TModel>> GetCards()
        {
            try
            {
                return await _cmcContext.Set<TModel>().ToListAsync();   
            }catch (Exception ex)
            {
                throw;
            }
        }

        public User Login(string username, string password)
        {
            ////return User that have username and password
            if (username == null || password == null)
            {
                return null;
            }
            else
            {
                return _cmcContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }
    }
}
