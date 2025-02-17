using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
	public class TransactionHeaderRepository
	{
        private static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static void InsertTransactionHeader(TransactionHeader transactionHeader)
		{
			db.TransactionHeaders.Add(transactionHeader);
			db.SaveChanges();

			return;
		}

		public static TransactionHeader GetLastTransactionHeader()
		{
			return db.TransactionHeaders.ToList().LastOrDefault();
		}

        public static List<TransactionHeader> GetTransactionHeadersByUserId(int userId)
        {
			return db.TransactionHeaders.Where(th => th.CustomerID.Equals(userId)).ToList();
        }

        public static List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public static TransactionHeader GetTransactionHeaderById(int transactionId)
        {
            return db.TransactionHeaders.Where(th => th.TransactionID.Equals(transactionId)).FirstOrDefault();
        }
    }
}