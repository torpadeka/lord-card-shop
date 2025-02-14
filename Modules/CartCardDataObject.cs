using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Modules
{
	public class CartCardDataObject
	{
		public int CardID { get; set; }
		public String CardName { get; set; }
        public double CardPrice { get; set; }
        public int Quantity { get; set; }
    }
}