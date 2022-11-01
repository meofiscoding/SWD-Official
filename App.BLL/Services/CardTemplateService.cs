using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using App.BLL.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using App.BLL.DTO;

namespace App.BLL.Services
{
    public class CardTemplateService : ICardTemplateService
    {
        private readonly ICardTemplateRepository<CardTemplateDTO> _cardTemplateRepository;

        public CardTemplateService(ICardTemplateRepository<CardTemplateDTO> cardTemplateRepository)
        {
            _cardTemplateRepository = cardTemplateRepository;
        }

        public Task AddCardTemplate(CardTemplateDTO templateCard)
        {
            //convert to CardTemplate Entity
            var cardTemplate = new TemplateCard
            {
                TemplateId = templateCard.TemplateId,
                TypeId = templateCard.TypeId,
                Title = templateCard.Title,
                Price = templateCard.Price,
                Status = templateCard.Status,
                CreatedAt = templateCard.CreatedAt,
                UpdatedAt = templateCard.UpdatedAt,
                FileName = templateCard.FileName
            };
            return _cardTemplateRepository.AddCard(cardTemplate);
        }

        public CardTemplateDTO FindTemplateCard(int? id)
        {
            var cardTemplate = _cardTemplateRepository.FindCardTemplate(id);
            //convert to CardTemplateDTO
            var templateCard = new CardTemplateDTO
            {
                TemplateId = cardTemplate.TemplateId,
                TypeId = cardTemplate.TypeId,
                Title = cardTemplate.Title,
                Price = cardTemplate.Price,
                Status = cardTemplate.Status,
                CreatedAt = cardTemplate.CreatedAt,
                UpdatedAt = cardTemplate.UpdatedAt,
                FileName = cardTemplate.FileName
            };
            return templateCard;
        }

        public async Task<List<CardTemplateDTO>> GetCardTemplates()
        {
            try
            {
                var templateCards = await _cardTemplateRepository.GetCardTemplates().ToListAsync();
                //convert to DTO
                var cardTemplateDTOs = new List<CardTemplateDTO>();
                foreach (var templateCard in templateCards)
                {
                    var cardTemplateDTO = new CardTemplateDTO
                    {
                        TemplateId = templateCard.TemplateId,
                        TypeId = templateCard.TypeId,
                        Title = templateCard.Title,
                        Price = templateCard.Price,
                        Status = templateCard.Status,
                        FileName = templateCard.FileName,
                        CreatedAt = templateCard.CreatedAt,
                        UpdatedAt = templateCard.UpdatedAt
                    };
                    cardTemplateDTOs.Add(cardTemplateDTO);
                }
                return cardTemplateDTOs ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CardTemplateDTO> GetCardTemplatesByTypes(int? id)
        {
            var cardTemplate = _cardTemplateRepository.GetTemplatesCard(id);
            //convert to DTO
            var cardTemplateDTOs = new List<CardTemplateDTO>();
            foreach (var templateCard in cardTemplate)
            {
                var cardTemplateDTO = new CardTemplateDTO
                {
                    TemplateId = templateCard.TemplateId,
                    TypeId = templateCard.TypeId,
                    Title = templateCard.Title,
                    Price = templateCard.Price,
                    Status = templateCard.Status,
                    FileName = templateCard.FileName,
                    CreatedAt = templateCard.CreatedAt,
                    UpdatedAt = templateCard.UpdatedAt
                };
                cardTemplateDTOs.Add(cardTemplateDTO);
            }
            return cardTemplateDTOs;
        }

        public CardTemplateDTO GetDetailCardtemplateByType(int? id)
        {
            var cardTemplate = _cardTemplateRepository.GetDetails(id);
            //convert to DTO
            var cardTemplateDTO = new CardTemplateDTO
            {
                TemplateId = cardTemplate.TemplateId,
                TypeId = cardTemplate.TypeId,
                Title = cardTemplate.Title,
                Price = cardTemplate.Price,
                Status = cardTemplate.Status,
                CreatedAt = cardTemplate.CreatedAt,
                UpdatedAt = cardTemplate.UpdatedAt,
                TypeName = cardTemplate.Type.TypeName
            };
            return cardTemplateDTO;
        }

        public bool IsExist(int id)
        {
            return _cardTemplateRepository.IsExist(id);
        }

        public Task RemoveCardTemplate(CardTemplateDTO templateCard)
        {
            //convert templateCard to CardTemplate Entity
            var cardTemplate = new TemplateCard
            {
                TemplateId = templateCard.TemplateId,
                TypeId = templateCard.TypeId,
                Title = templateCard.Title,
                Price = templateCard.Price,
                Status = templateCard.Status,
                CreatedAt = templateCard.CreatedAt,
                UpdatedAt = templateCard.UpdatedAt,
                FileName = templateCard.FileName
            };
            return _cardTemplateRepository.RemoveCard(cardTemplate);
        }

        public Task UpdateCardTemplate(CardTemplateDTO templateCard)
        {
            //convert templateCard to CardTemplate Entity
            var cardTemplate = new TemplateCard
            {
                TemplateId = templateCard.TemplateId,
                TypeId = templateCard.TypeId,
                Title = templateCard.Title,
                Price = templateCard.Price,
                Status = templateCard.Status,
                CreatedAt = templateCard.CreatedAt,
                UpdatedAt = templateCard.UpdatedAt,
                FileName = templateCard.FileName
            };
            return _cardTemplateRepository.UpdateCard(cardTemplate);
        }
    }
}
