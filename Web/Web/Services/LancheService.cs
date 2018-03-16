using System.Collections.Generic;
using Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ReadAsAsyncCore;

namespace Web.Services
{
    public class LancheService : ILancheService
    {
        public async Task<List<Lanche>> Listar()
        {
            HttpClient client = new HttpClient();
            List<Lanche> lanches = null;
            var path = "lanches";
            client.BaseAddress = new Uri("http://localhost:5001/");
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                lanches = await response.Content.ReadAsJsonAsync<List<Lanche>>();
            }
            return lanches;
        }
    }
}