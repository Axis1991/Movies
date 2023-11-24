﻿namespace BlazorApp1.Client.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage) 
        {
            Success = success;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }
        public bool Success { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
