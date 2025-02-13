using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class CardRepository
    {
        private static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Card> GetAllCards()
        {
            List<Card> cards = db.Cards.ToList();

            return cards;
        }

        public static Card GetCardById(int cardId)
        {
            Card card = db.Cards.Where(c => c.CardID.Equals(cardId)).FirstOrDefault();

            return card;
        }
    }
}