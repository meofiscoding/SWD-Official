using App.BLL.DTO;
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
        public Task<List<CardTypeDTO>> GetCardTypesAsync();
        public string GetCardTypeName(int? id);
        Task CreateCard(CardTypeDTO cardType);
        CardTypeDTO FindCardTypes(int? id);
        Task UpdateCard(CardTypeDTO cardType);
        bool IsExistCardTypes(int id);
        Task Delete(int id);
    }
}
