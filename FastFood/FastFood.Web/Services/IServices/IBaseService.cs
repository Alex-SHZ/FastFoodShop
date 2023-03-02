using System;
using FastFood.Web.Models;

namespace FastFood.Web.Services.IServices
{
	public interface IBaseService : IDisposable
	{
		ResponseDTO responseModel { get; set; }
		Task<T> SendAsync<T>(ApiRequest apiRequest);

	}
}

