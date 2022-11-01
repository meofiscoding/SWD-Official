using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using App.BLL.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.BLL.Services
{
    public class CardTemplateService : ICardTemplateService
    {
        private readonly ICardTemplateRepository<TemplateCard> _cardTemplateRepository;

        public CardTemplateService(ICardTemplateRepository<TemplateCard> cardTemplateRepository)
        {
            _cardTemplateRepository = cardTemplateRepository;
        }

        public Task AddCardTemplate(TemplateCard templateCard)
        {
            return _cardTemplateRepository.AddCard(templateCard);
        }

        public TemplateCard FindTemplateCard(int? id)
        {
            return _cardTemplateRepository.FindCardTemplate(id);
        }

        public async Task<List<TemplateCard>> GetCardTemplates()
        {
            try
            {
                return await _cardTemplateRepository.GetCardTemplates().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TemplateCard> GetCardTemplatesByTypes(int? id)
        {
            return _cardTemplateRepository.GetTemplatesCard(id);
        }

        public TemplateCard GetDetailCardtemplateByType(int? id)
        {
            return _cardTemplateRepository.GetDetails(id);
        }

        public bool IsExist(int id)
        {
            return _cardTemplateRepository.IsExist(id);
        }

        public Task RemoveCardTemplate(TemplateCard templateCard)
        {
            return _cardTemplateRepository.RemoveCard(templateCard);
        }

        public Task UpdateCardTemplate(TemplateCard templateCard)
        {
            return _cardTemplateRepository.UpdateCard(templateCard);
        }
    }
}
