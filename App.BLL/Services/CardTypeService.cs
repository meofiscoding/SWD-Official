using App.BLL.Services.Contracts;
using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class CardTypeService: ICardTypeService
    {
        private readonly ICardTypeRepository<CardType> _cardTypeRepository;

        public CardTypeService(ICardTypeRepository<CardType> cardTypeRepository)
        {
            _cardTypeRepository = cardTypeRepository;
        } 

        async Task<List<CardType>> ICardTypeService.GetCardTypesAsync()
        {
            try
            {
                return await _cardTypeRepository.GetCardTypes().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
