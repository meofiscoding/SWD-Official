using App.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Contracts
{
    public interface ICardTypeRepository<TModels> where TModels : class
    {
        IQueryable<CardType> GetCardTypes();
    }
}
