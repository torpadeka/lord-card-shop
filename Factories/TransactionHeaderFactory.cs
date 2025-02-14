using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
	public class TransactionHeaderFactory
	{
        public static TransactionHeader Create(int transactionId, DateTime transactionDate, int customerId, String status)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionID = transactionId,
                TransactionDate = transactionDate,
                CustomerID = customerId,
                Status = status
            };

            return transactionHeader;
        }
    }
}