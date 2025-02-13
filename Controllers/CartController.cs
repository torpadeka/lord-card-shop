using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controllers
{
    public class CartController
    {
        public static Response<Cart> AddCardToCart(int cardId, int userId)
        {
            return CartHandler.AddCardToCart(cardId, userId);
        }
    }
}