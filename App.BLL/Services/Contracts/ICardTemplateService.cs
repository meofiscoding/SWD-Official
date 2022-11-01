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
        List<TemplateCard>? GetCardTemplatesByCardType(int? id);
    }
}
