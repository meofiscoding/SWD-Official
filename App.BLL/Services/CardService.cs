using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.Models;
using App.DAL.Repositories.Contracts;
using App.BLL.Services.Contracts;

namespace App.BLL.Services
{
    public class CardService : ICardService
    {
        private readonly IGenericRepository<Card> _cardRepository;

        public CardService(IGenericRepository<Card> cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<List<Card>> GetCards()
        {
            try
            {
                return await _cardRepository.GetCards();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
