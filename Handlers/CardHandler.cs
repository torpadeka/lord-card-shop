using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Handlers
{
    public class CardHandler
    {
        public static Response<List<Card>> GetAllCards()
        {
            List<Card> cards = CardRepository.GetAllCards();

            return new Response<List<Card>>()
            {
                Success = true,
                Message = "All cards succesfully fetched!",
                Payload = cards
            };
        }
    }
}