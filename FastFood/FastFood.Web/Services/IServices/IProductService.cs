using System;
using FastFood.Web.Models;

namespace FastFood.Web.Services.IServices;

public interface IProductService
{
    Task<T> GetAllProductsAsync<T>();
    Task<T> GetProductByIdAsync<T>(int id);
    Task<T> CreateProductsAsync<T>(ProductDTO productDTO);
    Task<T> UpdateProductsAsync<T>(ProductDTO productDTO);
    Task<T> DeleteProductsAsync<T>(int id);
}

