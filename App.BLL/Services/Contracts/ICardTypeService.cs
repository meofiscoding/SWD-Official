using App.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services.Contracts
{
    public interface ICardTypeService
    {
        public Task<List<CardType>> GetCardTypesAsync();
        public string GetCardTypeName(int? id);
        Task CreateCard(CardType cardType);
        CardType FindCardTypes(int? id);
        Task UpdateCard(CardType cardType);
        bool IsExistCardTypes(int id); 
    }
}
