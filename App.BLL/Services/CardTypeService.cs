using App.BLL.Services.Contracts;
using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore; 

namespace App.BLL.Services
{
    public class CardTypeService: ICardTypeService
    {
        private readonly ICardTypeRepository<CardType> _cardTypeRepository;

        public CardTypeService(ICardTypeRepository<CardType> cardTypeRepository)
        {
            _cardTypeRepository = cardTypeRepository;
        }

        public Task CreateCard(CardType cardType)
        {
            return _cardTypeRepository.CreateCard(cardType);
        } 

        public CardType FindCardTypes(int? id)
        {
            return _cardTypeRepository.FindCardType(id);
        }

        public string GetCardTypeName(int? id)
        {
            try
            {
                return _cardTypeRepository.GetTypeName(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExistCardTypes(int id)
        {
            return _cardTypeRepository.IsExistCardTypes(id);
        }

        public Task UpdateCard(CardType cardType)
        {
            return _cardTypeRepository.UpdateCard(cardType);
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
