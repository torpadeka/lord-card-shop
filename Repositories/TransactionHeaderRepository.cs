using LOrd_Card_Shop.Models;
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
	}
}