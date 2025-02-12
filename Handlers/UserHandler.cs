using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace LOrd_Card_Shop.Handlers
{
    public class UserHandler
    {
        private static int GenerateUserID()
        {
            User user = UserRepository.GetLastUser();

            if (user == null)
            {
                return 1;
            }

            return user.UserID + 1;
        }

        public static Response<User> RegisterUser(String userName, String userEmail, String userPassword, String userGender, DateTime userDob, String userRole)
        {
            User user = UserFactory.Create(GenerateUserID(), userName, userEmail, userPassword, userGender, userDob, userRole);

            // Make sure email and username is unique

            if (UserRepository.GetUserByEmail(userEmail) != null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Email is already registered in another account!",
                    Payload = null
                };
            }

            if (UserRepository.GetUserByUsername(userName) != null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Username is taken!",
                    Payload = null
                };
            }

            UserRepository.InsertUser(user);

            return new Response<User>()
            {
                Success = true,
                Message = "Registration successful!",
                Payload = user
            };
        }

        public static Response<User> LoginUser(String userName, String userPassword)
        {
            User user = UserRepository.GetUserByUsername(userName);
            
            if(user == null)
            {
                // if the username doesn't yield a user
                return new Response<User>()
                {
                    Success = false,
                    Message = "User not found!",
                    Payload = null
                };
            }

            if(user.UserPassword != userPassword)
            {
                // if the user with the username is found, but the password's wrong
                return new Response<User>()
                {
                    Success = false,
                    Message = "Invalid credentials!",
                    Payload = null
                };
            }
            else
            {
                // if the user is found and the password's correct
                return new Response<User>()
                {
                    Success = true,
                    Message = "Login successful!",
                    Payload = user
                };
            }
        }
        public static Response<User> LoginUserByCookie(String cookie)
        {

            String decryptedCookie = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(cookie)));

            Int32.TryParse(decryptedCookie, out int userId);

            User user = UserRepository.GetUserById(userId);

            if (user == null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "User not found!",
                    Payload = null
                };
            }

            return new Response<User>()
            {
                Success = true,
                Message = "Cookie login successful! Session extended.",
                Payload = user
            };
        }
    }
}