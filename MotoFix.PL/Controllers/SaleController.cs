using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoFix.BLL.Interfaces;
using MotoFix.DAL.Models;
using System.Globalization;

namespace MotoFix.PL.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string? date)
        {

            IEnumerable<Sale> sales;
            if (date != null)
            {
                DateTime result;
                DateTime.TryParseExact(date,"yyyy-MM-dd", CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out result);
                sales = _unitOfWork.SaleRepository.GetByDate(result.Date);
                return View(sales);
            }
            sales = await _unitOfWork.SaleRepository.GetAllAsync();
            return View(sales);
        }

        public async Task<IActionResult> Create(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product == null || product.QuantityInStock <= 0)
            {
                TempData["Message"] = "المنتج غير متوفر";
                return RedirectToAction(nameof(Index),"Product");
            }


            // Create a new Sale
            var sale = new Sale
            {
                SaleDate = DateTime.Now,
               
            };

            await _unitOfWork.SaleRepository.AddAsync(sale);
            await _unitOfWork.CompleteAsync(); // Commit changes to generate SaleId

            // Create a new SaleItem to record this sale
            var saleItem = new SaleItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = 1,
                SellingPrice = product.SellingPrice,
                SaleId = sale.Id,
                PurchasePrice = product.PurchasePrice,
                Profit = product.SellingPrice - product.PurchasePrice
            };




            // Decrease the product quantity by one

            product.QuantityInStock -= 1;

            // Add the SaleItem to the SaleItem table

            await _unitOfWork.SaleItemRepository.AddAsync(saleItem);
            // Update the product in the database

            _unitOfWork.ProductRepository.Update(product);

            // Commit the changes to the database
            int Result = await _unitOfWork.CompleteAsync();
            if (Result > 0)
                TempData["Message"] = "تم البيع";
            return RedirectToAction(nameof(Index), "Product");
        }
    }
}
