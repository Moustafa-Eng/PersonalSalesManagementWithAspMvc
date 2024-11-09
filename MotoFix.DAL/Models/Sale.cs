using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.DAL.Models
{
	public class Sale
	{
		public int Id { get; set; }
		public DateTime SaleDate { get; set; }  = DateTime.Now;

        public int? CustomerId { get; set; }
        public CustomerAccount Customer { get; set; } // Navigation property

        public ICollection<SaleItem> SaleItems { get; set; } = new HashSet<SaleItem>();
	}
}
