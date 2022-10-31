﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace App.DAL.Repositories.Contracts
{
    public interface ICardTemplateRepository<TModels> where TModels : class
    {
        IIncludableQueryable<TemplateCard,CardType> GetCardTemplates();
    }
}