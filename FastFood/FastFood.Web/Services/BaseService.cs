using System;
using System.Text;
using FastFood.Web.Models;
using FastFood.Web.Services.IServices;
using Newtonsoft.Json;

namespace FastFood.Web.Services;

public class BaseService : IBaseService
{
    public ResponseDTO responseModel { get; set;}
    public IHttpClientFactory httpClient { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
        this.httpClient = httpClient;
        this.responseModel = new ResponseDTO();

    }

    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var client = httpClient.CreateClient("FastFoodAPI");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();
            if (apiRequest.Data != null)
                message.Content = new StringContent(JsonConvert
                    .SerializeObject(apiRequest.Data)
                    ,Encoding.UTF8
                    ,"application/json");

            HttpResponseMessage apiResponse = null;
            switch (apiRequest.ApiType)
            {
                case StaticDetails.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case StaticDetails.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case StaticDetails.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);

            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);

            return apiResponseDTO;

        }
        catch (Exception ex)
        {
            var dto = new ResponseDTO()
            {
                DisplayMessage = "Error",
                ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                IsSuccess = false,
            };
            var res = JsonConvert.SerializeObject(dto);
            var apiResponseDTO = JsonConvert.DeserializeObject<T>(res);
            return apiResponseDTO;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }
}

