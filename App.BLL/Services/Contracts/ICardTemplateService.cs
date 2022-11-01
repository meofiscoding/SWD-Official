using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Entity;

namespace App.BLL.Services.Contracts
{
    public interface ICardTemplateService
    {
        Task<List<TemplateCard>> GetCardTemplates();
        TemplateCard GetDetailCardtemplateByType(int? id);
        Task AddCardTemplate(TemplateCard templateCard);
        TemplateCard FindTemplateCard(int? id);
        Task UpdateCardTemplate(TemplateCard templateCard);
        bool IsExist(int id);
        List<TemplateCard> GetCardTemplatesByTypes(int? id);
        Task RemoveCardTemplate(TemplateCard templateCard);
    }
}
