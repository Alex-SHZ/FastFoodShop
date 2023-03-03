using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FastFood.Web.Models;
using FastFood.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FastFood.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
        List<ProductDTO> list = new();
        var response = await _productService.GetAllProductsAsync<ResponseDTO>();
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert
                .DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
        }
        return View(list);
    }

    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductCreate(ProductDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProductsAsync<ResponseDTO>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
            return View(model);
        
    }

    public async Task<IActionResult> ProductEdit(int productId)
    {
        var response = await _productService
            .GetProductByIdAsync<ResponseDTO>(productId);
        if (response != null && response.IsSuccess)
        {
            ProductDTO model = JsonConvert
                .DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
            return View(model);
        }
        return NotFound();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductEdit(ProductDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.UpdateProductsAsync<ResponseDTO>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
        return View(model);
    }

    public async Task<IActionResult> ProductDelete(int productId)
    {
        var response = await _productService
            .GetProductByIdAsync<ResponseDTO>(productId);
        if (response != null && response.IsSuccess)
        {
            ProductDTO model = JsonConvert
                .DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
            return View(model);
        }
        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductDelete(ProductDTO model)
    {
            var response = await _productService.DeleteProductsAsync<ResponseDTO>(model.ProductId);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        return View(model);
    }
}

