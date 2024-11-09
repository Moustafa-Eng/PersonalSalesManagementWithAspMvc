using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoFix.DAL.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } // Not Null In .Net 8.0

		[InverseProperty("Category")]
		public ICollection<Product> Products { get; set; } = new HashSet<Product>();
	}
}
