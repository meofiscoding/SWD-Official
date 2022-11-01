using App.BLL.DTO;
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

        public Task CreateCard(CardTypeDTO cardType)
        {
            // convert cardTypeDTO to CardType Entity
            var cardTypeEntity = new CardType
            {
                TypeId = cardType.TypeId,
                TypeName = cardType.TypeName,
                Status = cardType.Status ,
                Detail = cardType.Detail
            }; 
            return _cardTypeRepository.CreateCard(cardTypeEntity);
        } 

        public CardTypeDTO FindCardTypes(int? id)
        {
            var cardType = _cardTypeRepository.FindCardType(id);
            //convert cardType to cardTypeDTO
            var cardTypeDTO = new CardTypeDTO
            {
                TypeId = cardType.TypeId,
                TypeName = cardType.TypeName,
                Status = cardType.Status 
            };
            return cardTypeDTO;
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

        public Task UpdateCard(CardTypeDTO cardType)
        {
            //convert cardTypeDTO to CardType Entity
            var cardTypeEntity = new CardType
            {
                TypeId = cardType.TypeId,
                TypeName = cardType.TypeName,
                Status = cardType.Status ,
                Detail = cardType.Detail
            };
            return _cardTypeRepository.UpdateCard(cardTypeEntity);
        }

        public async Task<List<CardTypeDTO>> GetCardTypesAsync()
        {
            try
            {
                var cardTypes = await _cardTypeRepository.GetCardTypes().ToListAsync();
                var cardTypesDTO = new List<CardTypeDTO>();
                foreach (var item in cardTypes)
                {
                    cardTypesDTO.Add(new CardTypeDTO
                    {
                        TypeId = item.TypeId,
                        TypeName = item.TypeName,
                        Status = item.Status,
                        Detail = item.Detail,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt
                    });
                };
                return cardTypesDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task Delete(int id)
        {
            return _cardTypeRepository.DeleteCard(id);
        }
    }
}
