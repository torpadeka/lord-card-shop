using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Handlers
{
	public class TransactionHandler
	{
        private static int GenerateTransactionHeaderId()
        {
            TransactionHeader transactionHeader = TransactionHeaderRepository.GetLastTransactionHeader();

            if (transactionHeader == null)
            {
                return 1;
            }

            return transactionHeader.TransactionID + 1;
        }

        public static Response<TransactionHeader> CreateTransactionHeader(int customerId)
		{
			TransactionHeader transactionHeader = TransactionHeaderFactory.Create(GenerateTransactionHeaderId(), DateTime.Now, customerId, "Unhandled");

			TransactionHeaderRepository.InsertTransactionHeader(transactionHeader);

            return new Response<TransactionHeader>()
			{
				Success = true,
				Message = "Transaction header created successfully!",
				Payload = transactionHeader
            };
		}

        public static Response<TransactionDetail> CreateTransactionDetail(int transactionId, int cardId, int quantity)
        {
            TransactionDetail transactionDetail = TransactionDetailFactory.Create(transactionId, cardId, quantity);

            TransactionDetailRepository.InsertTransactionDetail(transactionDetail);

            return new Response<TransactionDetail>()
            {
                Success = true,
                Message = "Transaction detail created successfully!",
                Payload = transactionDetail
            };
        }
    }
}