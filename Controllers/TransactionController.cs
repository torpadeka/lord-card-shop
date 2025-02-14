using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controllers
{
	public class TransactionController
	{
        public static Response<TransactionHeader> CreateTransactionHeader(int customerId)
        {
            return TransactionHandler.CreateTransactionHeader(customerId);
        }

        public static Response<TransactionDetail> CreateTransactionDetail(int transactionId, int cardId, int quantity)
        {
            return TransactionHandler.CreateTransactionDetail(transactionId, cardId, quantity);
        }
    }
}