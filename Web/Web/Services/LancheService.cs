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
        private HttpClient _client;

        public LancheService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5001/");            
        }
        public async Task<List<Lanche>> Listar()
        {
            List<Lanche> lanches = null;
            
            HttpResponseMessage response = await _client.GetAsync("lanches");
            if (response.IsSuccessStatusCode)
            {
                lanches = await response.Content.ReadAsJsonAsync<List<Lanche>>();
            }
            return lanches;
        }

        public async Task<Lanche> Obter(int id)
        {
            Lanche lanche = null;
            
            HttpResponseMessage response = await _client.GetAsync("lanches/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                lanche = await response.Content.ReadAsJsonAsync<Lanche>();
            }
            return lanche;
        }

        public async Task<List<Ingrediente>> ListarIngredientes()
        {
            List<Ingrediente> ingredientes = null;
            
            HttpResponseMessage response = await _client.GetAsync("ingredientes");
            if (response.IsSuccessStatusCode)
            {
                ingredientes = await response.Content.ReadAsJsonAsync<List<Ingrediente>>();
            }
            return ingredientes;
        }
    }
}