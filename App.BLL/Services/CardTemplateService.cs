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
    }
}
