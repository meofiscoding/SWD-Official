using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.BLL.Services.Contracts
{
    public interface IAccountService
    {
        public User Login(string username, string password);
        
    }
}
