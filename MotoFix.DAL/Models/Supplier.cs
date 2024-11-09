using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.DAL.Models
{
	public class Supplier
	{
		public int Id { get; set; }
		public string Name { get; set; }  
		public string? ContactEmail { get; set; }
		public string Phone { get; set; }  
		public string? Address { get; set; }

		[InverseProperty("Suppliers")]
		public ICollection<Product> Products { get; set; } = new HashSet<Product>();
	}
}
