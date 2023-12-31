﻿using System.Text;
using System.Text.Json;

namespace BlazorApp1.Client.Helpers
{
    public class HttpService: IHttpService
    {
        private readonly HttpClient httpClient;
        public HttpService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }
    }
}
