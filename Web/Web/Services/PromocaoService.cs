using System.Collections.Generic;
using Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ReadAsAsyncCore;
using Newtonsoft.Json;

namespace Web.Services
{
    public class PromocaoService : IPromocaoService
    {
        private HttpClient _client;

        public PromocaoService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5002/");            
        }
        public async Task<Desconto> CalculaDesconto(Lanche lanche)
        {
            Desconto desconto = null;
            var myContent = JsonConvert.SerializeObject(lanche);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            HttpResponseMessage response = await _client.PostAsync("calcula-desconto", byteContent);
            if (response.IsSuccessStatusCode)
            {
                desconto = await response.Content.ReadAsJsonAsync<Desconto>();
            }
            return desconto;
        }

    }
}