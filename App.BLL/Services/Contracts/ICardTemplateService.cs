using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BLL.DTO;
using App.DAL.Entity;

namespace App.BLL.Services.Contracts
{
    public interface ICardTemplateService
    {
        Task<List<CardTemplateDTO>> GetCardTemplates();
        CardTemplateDTO GetDetailCardtemplateByType(int? id);
        Task AddCardTemplate(CardTemplateDTO templateCard);
        CardTemplateDTO FindTemplateCard(int? id);
        Task UpdateCardTemplate(CardTemplateDTO templateCard);
        bool IsExist(int id);
        List<CardTemplateDTO> GetCardTemplatesByTypes(int? id);
        Task RemoveCardTemplate(int id);
    }
}
