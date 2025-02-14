using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controllers
{
    public class CardController
    {
        public static Response<List<Card>> GetAllCards()
        {
            return CardHandler.GetAllCards();
        }

        public static Response<Card> GetCardById(int cardId)
        {
            return CardHandler.GetCardById(cardId);
        }
    }
}