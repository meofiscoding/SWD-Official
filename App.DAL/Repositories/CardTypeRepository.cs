using App.DAL.DataContext;
using App.DAL.Entity;
using App.DAL.Repositories.Contracts;
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

        public IQueryable<CardType> GetCardTypes()
        {
            return _cmcContext.CardTypes.Where(m => m.Status == 1);
        }
    }
}
