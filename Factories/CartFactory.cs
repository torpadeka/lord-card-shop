using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
    public class CartFactory
    {
        public static Cart Create(int cartId, int cardId, int userId, int quantity)
        {
            Cart cart = new Cart()
            {
                CartID = cartId,
                CardID = cardId,
                UserID = userId,
                Quantity = quantity
            };

            return cart;
        }
    }
}