using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.DAL.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal PurchasePrice { get; set; }
		public decimal SellingPrice { get; set; }
		public int QuantityInStock { get; set; }  

		[ForeignKey("Category")]
		public int? CategoryId { get; set; }

		[InverseProperty("Products")]
		public Category Category { get; set; }




        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
		[InverseProperty("Products")]
		public ICollection<Supplier> Suppliers { get; set; } = new HashSet<Supplier>(); 
	}
}
