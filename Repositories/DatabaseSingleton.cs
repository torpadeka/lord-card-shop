using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class DatabaseSingleton
    {
        private static LocalDatabaseEntities instance;

        public static LocalDatabaseEntities GetInstance()
        {
            if(instance == null)
            {
                instance = new LocalDatabaseEntities();
            }

            return instance;
        }
    }
}