using App.DAL.DataContext;
using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class CardTypeRepository<TModel> : ICardTypeRepository<TModel> where TModel : class
    {
        private readonly CMCContext _cmcContext;

        public CardTypeRepository(CMCContext cmcContext)
        {
            _cmcContext = cmcContext;
        }

        public async Task CreateCard(CardType cardType)
        {
            _cmcContext.Add(cardType);
            await _cmcContext.SaveChangesAsync();
        }

        public Task DeleteCard(int id)
        {
            var cardType = _cmcContext.CardTypes.Find(id);
            //remove all cardtemplate that have this cardtype
            var cardTemplates = _cmcContext.TemplateCards.Where(t => t.TypeId == id);
            _cmcContext.TemplateCards.RemoveRange(cardTemplates);
            _cmcContext.CardTypes.Remove(cardType) ;
            return _cmcContext.SaveChangesAsync();
        }

        public CardType FindCardType(int? id)
        {
            return _cmcContext.CardTypes.Find(id);
        }

        public IQueryable<CardType> GetCardTypes()
        {
            //get all card type 
            return _cmcContext.CardTypes;
        }

        public string GetTypeName(int? id)
        {
            var cardtype = _cmcContext.CardTypes.Find(id);
            if ( cardtype!= null)
            {
                return cardtype.TypeName.ToString();
            }
            return "";
        }

        public bool IsExistCardTypes(int id)
        {
            return _cmcContext.CardTypes.Any(e => e.TypeId == id);
        }

        public Task UpdateCard(CardType cardType)
        {
            _cmcContext.Update(cardType);
            return _cmcContext.SaveChangesAsync();
        }
    }
}
