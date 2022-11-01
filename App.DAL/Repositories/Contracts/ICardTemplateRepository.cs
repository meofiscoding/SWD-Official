using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Entity;
using Microsoft.EntityFrameworkCore.Query;

namespace App.DAL.Repositories.Contracts
{
    public interface ICardTemplateRepository<TModels> where TModels : class
    {
        IIncludableQueryable<TemplateCard,CardType> GetCardTemplates();
        TemplateCard GetDetails(int? id);
        Task AddCard(TemplateCard templateCard);
        TemplateCard FindCardTemplate(int? id);
        Task UpdateCard(TemplateCard templateCard);
        bool IsExist(int id);
        List<TemplateCard> GetTemplatesCard(int? id);
        Task RemoveCard(int id);
    }
}
