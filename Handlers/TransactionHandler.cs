using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

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

        public static Response<List<TransactionHeader>> GetTransactionHeadersByUserId(int userId)
        {
            List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.GetTransactionHeadersByUserId(userId);

            return new Response<List<TransactionHeader>>()
            {
                Success = true,
                Message = "All transaction headers of this user fetched successfully!",
                Payload = transactionHeaders
            };
        }

        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            List<TransactionHeader> transactionHeaders = TransactionHeaderRepository.GetAllTransactionHeaders();

            return new Response<List<TransactionHeader>>()
            {
                Success = true,
                Message = "All transaction headers fetched successfully!",
                Payload = transactionHeaders
            };
        }

        public static Response<TransactionHeader> GetTransactionHeaderById(int transactionId)
        {
            TransactionHeader transactionHeader = TransactionHeaderRepository.GetTransactionHeaderById(transactionId);

            return new Response<TransactionHeader>()
            {
                Success = true,
                Message = "Transaction header fetched successfully!",
                Payload = transactionHeader
            };
        }

        public static Response<List<TransactionDetail>> GetTransactionDetailsById(int transactionId)
        {
            List<TransactionDetail> transactionDetails = TransactionDetailRepository.GetTransactionDetailsById(transactionId);

            return new Response<List<TransactionDetail>>()
            {
                Success = true,
                Message = "Transaction header fetched successfully!",
                Payload = transactionDetails
            };
        }

        public static Response<List<TransactionCardDataObject>> GetTransactionsAndCards(int transactionId)
        {
            List<TransactionDetail> transactionDetails = TransactionDetailRepository.GetTransactionDetailsById(transactionId);

            List<Card> cards = new List<Card>();

            foreach (TransactionDetail td in transactionDetails)
            {
                cards.Add(CardRepository.GetCardById(td.CardID));
            }

            List<TransactionCardDataObject> transactionCards = (from td in transactionDetails
                                                                join card in cards
                                                                on td.CardID equals card.CardID
                                                                select new TransactionCardDataObject
                                                                {
                                                                    CardID = card.CardID,
                                                                    CardName = card.CardName,
                                                                    CardPrice = card.CardPrice,
                                                                    Quantity = td.Quantity
                                                                }).ToList();

            return new Response<List<TransactionCardDataObject>>()
            {
                Success = true,
                Message = "Transactions with corresponding cards fetched successfully!",
                Payload = transactionCards
            };
        }
    }
}