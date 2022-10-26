using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Models;

namespace App.BLL.Services.Contracts
{
    public interface ICardService
    {
        Task<List<Card>> GetCards();
    }
}
