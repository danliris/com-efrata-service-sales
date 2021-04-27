﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.Purchasing.Lib.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
