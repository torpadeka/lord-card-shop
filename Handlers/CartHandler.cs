using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace LOrd_Card_Shop.Handlers
{
    public class CartHandler
    {
        private static int GenerateCartId()
        {
            Cart cart = CartRepository.GetLastCart();

            if (cart == null)
            {
                return 1;
            }

            return cart.CartID + 1;
        }

        public static Response<Cart> AddCardToCart(int cardId, int userId)
        {
            Cart existingCart = CartRepository.GetCartByCardId(cardId);

            if(existingCart == null)
            {
                Cart cart = CartFactory.Create(GenerateCartId(), cardId, userId, 1);
                CartRepository.InsertCart(cart);

                return new Response<Cart>
                {
                    Success = true,
                    Message = "Card added to new cart successfully!",
                    Payload = cart
                };
            }

            Cart updatedCart = CartRepository.AddCartQuantity(existingCart.CartID);

            return new Response<Cart>
            {
                Success = true,
                Message = "The quantity of an existing cart with this card has been added!",
                Payload = updatedCart
            };
        }
    }
}