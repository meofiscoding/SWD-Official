using App.DAL.DataContext;
using App.DAL.Models;
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

        IIncludableQueryable<TemplateCard, CardType> ICardTemplateRepository<TModel>.GetCardTemplates()
        {
            return _cmcContext.TemplateCards.Include(t => t.Type);
        }
    }
}
