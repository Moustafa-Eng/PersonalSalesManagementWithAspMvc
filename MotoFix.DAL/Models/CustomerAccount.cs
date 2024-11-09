using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.DAL.Models
{
	public class CustomerAccount
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime AccountDate { get; set; } = DateTime.Now;
		public decimal TotalAmount { get; set; }  
		public decimal TotalProfit { get; set; }  
		public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
	}
}
