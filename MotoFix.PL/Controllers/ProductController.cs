using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoFix.BLL.Interfaces;
using MotoFix.DAL.Models;
using MotoFix.PL.ViewModels;
using System.Collections.Generic;

namespace MotoFix.PL.Controllers
{
    [Authorize]
	public class ProductController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(string? SearchValue)
		{
            ViewBag.ActionName = "Index";

            IEnumerable<Product> products;
            IEnumerable<ProductViewModel> FinalProducts;
            if (string.IsNullOrEmpty(SearchValue))
                return View();

            products = _unitOfWork.ProductRepository.GetProductsByName(SearchValue);
            FinalProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return View(FinalProducts);
		}

        public async Task<IActionResult> GetAll(string? SearchValue)
        {
            ViewBag.ActionName = "GetAll";
            IEnumerable<Product> products;
            if (string.IsNullOrEmpty(SearchValue))
                products = await _unitOfWork.ProductRepository.GetAllAsync();
            else
                products = _unitOfWork.ProductRepository.GetProductsByName(SearchValue);
            IEnumerable<ProductViewModel> FinalProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return View(FinalProducts);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            ViewBag.Suppliers = await _unitOfWork.SupplierRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                var MappedProduct = _mapper.Map<ProductViewModel, Product>(model);
                await _unitOfWork.ProductRepository.AddAsync(MappedProduct);
                int Result = await _unitOfWork.CompleteAsync();
                if (Result > 0)
                    TempData["Message"] = "تم اضافة المنتج بنجاح";
                return RedirectToAction(nameof(Create));
            }

            return View(model);
        }



        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            ViewBag.Suppliers = await _unitOfWork.SupplierRepository.GetAllAsync();

            if (id == null)
                return BadRequest();

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id.Value);

            if (product == null)
                return NotFound();

            var MappedProduct = _mapper.Map<Product, ProductViewModel>(product);

            return View(MappedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model, [FromRoute] int id)
        {
            if(id != model.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedProduct = _mapper.Map<ProductViewModel, Product>(model);
                    _unitOfWork.ProductRepository.Update(MappedProduct);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(GetAll));
                }catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Delete(ProductViewModel model,[FromRoute]int id)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }
            try
            {
                var MappedProduct = _mapper.Map<ProductViewModel, Product>(model);
                _unitOfWork.ProductRepository.Delete(MappedProduct);
                int Result = await _unitOfWork.CompleteAsync();
            }catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(GetAll));
        }
    }
}
