using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
	public class TransactionDetailFactory
	{
        public static TransactionDetail Create(int transactionId, int cardId, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionId,
                CardID = cardId,
                Quantity = quantity
            };

            return transactionDetail;
        }
    }
}