using App.DAL.DataContext;
using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class CardTemplateRepository<TModel> : ICardTemplateRepository<TModel> where TModel : class
    {
        private readonly CMCContext _cmcContext;

        public CardTemplateRepository(CMCContext cmcContext)
        {
            _cmcContext = cmcContext;
        }

        public Task AddCard(TemplateCard templateCard)
        {
            _cmcContext.Add(templateCard);
            return _cmcContext.SaveChangesAsync();
        }

        public TemplateCard GetDetails(int? id)
        {
            return _cmcContext.TemplateCards.Include(t => t.Type).FirstOrDefault(m => m.TemplateId == id);
        }

        IIncludableQueryable<TemplateCard, CardType> ICardTemplateRepository<TModel>.GetCardTemplates()
        {
            return _cmcContext.TemplateCards.Include(t => t.Type);
        }

        public TemplateCard FindCardTemplate(int? id)
        {
            return _cmcContext.TemplateCards.Find(id);
        }

        public Task UpdateCard(TemplateCard templateCard)
        {

            _cmcContext.Update(templateCard);
            return _cmcContext.SaveChangesAsync();
        }

        public bool IsExist(int id)
        {
            return _cmcContext.TemplateCards.Any(e => e.TemplateId == id);
        }

        public List<TemplateCard> GetTemplatesCard(int? id)
        {
           return _cmcContext.TemplateCards.Where(t => t.TypeId == id).ToList();
        }

        public Task RemoveCard(TemplateCard templateCard)
        {
             _cmcContext.TemplateCards.Remove(templateCard);
            return _cmcContext.SaveChangesAsync();
        }
    }
}
