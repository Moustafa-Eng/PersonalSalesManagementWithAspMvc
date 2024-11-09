using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.DAL.Models
{
	public class SaleItem
	{
		public int Id { get; set; }
		public int ProductId { get; set; }  
		public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }  
		public decimal PurchasePrice { get; set; }
        public decimal Profit { get; set; }

        // Foreign key to Sale
        public int SaleId { get; set; }
        public Sale Sale { get; set; }

    }
}
