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
    public class PedidoService : IPedidoService
    {
        private HttpClient _client;

        public PedidoService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5003/");            
        }
        public async Task Criar(Pedido pedido)
        {
            var myContent = JsonConvert.SerializeObject(pedido);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            HttpResponseMessage response = await _client.PostAsync("pedidos", byteContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.Content.ToString());
            }            
        }

    }
}