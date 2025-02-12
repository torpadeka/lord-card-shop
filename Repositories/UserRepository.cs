using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class UserRepository
    {
        private static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static void InsertUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return;
        }

        public static User GetUserByUsername(String userName)
        {
            User user = db.Users.Where(u => u.UserName == userName).FirstOrDefault();

            return user;
        }

        public static User GetUserById(int userId)
        {
            User user = db.Users.Where(u => u.UserID == userId).FirstOrDefault();

            return user;
        }

        public static User GetUserByEmail(String userEmail)
        {
            User user = db.Users.Where(u => u.UserEmail.Equals(userEmail)).FirstOrDefault();

            return user;
        }

        public static User GetLastUser()
        {
            User user = db.Users.ToList().LastOrDefault();

            return user;
        }
    }
}