using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
    public class UserFactory
    {
        public static User Create(int userId, String userName, String userEmail, String userPassword, String userGender, DateTime userDob, String userRole)
        {
            User user = new User()
            {
                UserID = userId,
                UserName = userName,
                UserEmail = userEmail,
                UserPassword = userPassword,
                UserGender = userGender,
                UserDOB = userDob,
                UserRole = userRole
            };

            return user;
        }
    }
}