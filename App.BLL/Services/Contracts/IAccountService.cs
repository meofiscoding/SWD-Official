using App.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.BLL.Services.Contracts
{
    public interface IAccountService
    {
        public bool Login(string username, string password);
        public int GetRoleIDByName(string role);
    }
}
