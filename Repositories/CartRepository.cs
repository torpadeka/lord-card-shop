using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class CartRepository
    {
        private static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static void InsertCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();

            return;
        }

        public static Cart GetCartByCardId(int cardId)
        {
            return db.Carts.Where(c => c.CardID.Equals(cardId)).FirstOrDefault();
        }

        public static Cart GetLastCart()
        {
            return db.Carts.ToList().LastOrDefault();
        }

        public static Cart AddCartQuantity(int cartId)
        {
            Cart cart = db.Carts.Find(cartId);

            cart.Quantity++;
            db.SaveChanges();

            return cart;
        }

        public static List<Cart> GetCartsByUserId(int userId)
        {
            return db.Carts.Where(c => c.UserID.Equals(userId)).ToList();
        }
    }
}