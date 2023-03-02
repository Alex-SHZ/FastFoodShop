using System;
using FastFood.Web.Models;
using FastFood.Web.Services.IServices;
using static FastFood.Web.StaticDetails;

namespace FastFood.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateProductsAsync<T>(ProductDTO productDTO)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = productDTO,
                Url = StaticDetails.ProductAPIBase + "api/products",
                AccessToken = ""

            });
        }

        public async Task<T> DeleteProductsAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductAPIBase + "api/products"+id,
                AccessToken = ""

            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "api/products",
                AccessToken = ""

            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "api/products" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductsAsync<T>(ProductDTO productDTO)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = productDTO,
                Url = StaticDetails.ProductAPIBase + "api/products",
                AccessToken = ""

            });
        }
    }
}

