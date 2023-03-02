using FastFood.Services.ProductAPI.Models.DTO;
using FastFood.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductAPIController : ControllerBase
{
    protected ResponseDTO _response;
    private IProductRepository _productRepository; 

    public ProductAPIController(IProductRepository iProductReposytory)
    {
        _productRepository = iProductReposytory;
        this._response = new ResponseDTO();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductDTO> productDTOs
                = await _productRepository.GetProducts();
            _response.Result = productDTOs;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            ProductDTO productDTOs
                = await _productRepository.GetProductById(id);
            _response.Result = productDTOs;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] ProductDTO productDTO)
    {
        try
        {
            ProductDTO productDTOs
                = await _productRepository.CreateUpdateProduct(productDTO);
            _response.Result = productDTOs;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }

        return _response;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] ProductDTO productDTO)
    {
        try
        {
            ProductDTO productDTOs
                = await _productRepository.CreateUpdateProduct(productDTO);
            _response.Result = productDTOs;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSucess
                = await _productRepository.DeleteProduct(id);
            _response.Result = isSucess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

}

