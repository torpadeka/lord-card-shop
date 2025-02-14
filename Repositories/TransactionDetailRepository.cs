using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
	public class TransactionDetailRepository
	{
        private static LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

        public static void InsertTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();

            return;
        }

        public static TransactionDetail GetLastTransactionDetail()
        {
            return db.TransactionDetails.ToList().LastOrDefault();
        }
    }
}