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
        string GetTypeName(int? id);
        Task CreateCard(CardType cardType);
        CardType FindCardType(int? id);
        Task UpdateCard(CardType cardType);
        bool IsExistCardTypes(int id);
    }
}
