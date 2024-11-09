using MotoFix.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFix.PL.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ادخل الاسم من فضلك")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ادخل سعر الشراء من فضلك")]

        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "ادخل سعر البيع من فضلك")]

        public decimal SellingPrice { get; set; }
        [Required(ErrorMessage = "ادخل العدد من فضلك")]

        public int QuantityInStock { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [InverseProperty("Products")]
        public Category? Category { get; set; }




        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        [InverseProperty("Products")]
        public Supplier? Supplier { get; set; }

        public decimal Code { get; set; }

    }
}
