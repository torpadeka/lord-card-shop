using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
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

        public static List<TransactionDetail> GetTransactionDetailsById(int transactionId)
        {
            return db.TransactionDetails.Where(td => td.TransactionID.Equals(transactionId)).ToList();
        }
    }
}