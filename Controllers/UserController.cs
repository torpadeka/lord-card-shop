using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controllers
{
    public class UserController
    {
        public static Response<User> RegisterUser(String userName, String userEmail, String userPassword, String userGender, String confirmationPassword, DateTime userDob, String userRole)
        {
            String error = "";

            if (userName.Equals("") || userEmail.Equals("") || userPassword.Equals("") || userGender.Equals("") || confirmationPassword.Equals(""))
            {
                // userRole does not need validation, because they have default values
                error = "All fields must be filled!";
            }
            else if (!userEmail.Contains("@"))
            {
                error = "Email must contain '@'";
            }
            else if(userPassword.Length < 8)
            {
                error = "Password must at least be 8 characters!";
            }
            else if (!userPassword.Any(char.IsLetter) || !userPassword.Any(char.IsDigit))
            {
                error = "Password must be alphanumeric!";
            }
            else if (!confirmationPassword.Equals(userPassword))
            {
                error = "Confirmation password must be the same as password!";
            }
            else if(userDob == DateTime.MinValue)
            {
                error = "You must choose a Date of Birth!";
            }
            else if(userDob >= DateTime.Now)
            {
                error = "Date of Birth can't be in the future :)";
            }

            if (error.Equals(""))
            {
                return UserHandler.RegisterUser(userName, userEmail, userPassword, userGender, userDob, userRole);
            }

            return new Response<User>()
            {
                Success = false,
                Message = error,
                Payload = null
            };
        }

        public static Response<User> LoginUser(String username, String password)
        {

            String error = "";

            if (username.Equals("") || password.Equals(""))
            {
                error = "All fields must be filled!";
            }

            if (error.Equals(""))
            {
                return UserHandler.LoginUser(username, password);
            }

            return new Response<User>()
            {
                Success = false,
                Message = error,
                Payload = null
            };
        }

        public static Response<User> LoginUserByCookie(String cookie)
        {
            return UserHandler.LoginUserByCookie(cookie);
        }
    }
}