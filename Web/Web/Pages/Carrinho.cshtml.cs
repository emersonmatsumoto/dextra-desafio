using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models;
using Web.Services;

namespace Web.Pages
{
    public class CarrinhoModel : PageModel
    {
        private readonly ILancheService _lancheService;
        private readonly IPromocaoService _promocaoService;
        private readonly IPedidoService _pedidoService;

        public CarrinhoModel(ILancheService lancheService, IPromocaoService promocaoService, IPedidoService pedidoService)
        {
            _lancheService = lancheService;
            _promocaoService = promocaoService;
            _pedidoService = pedidoService;
        }

        [BindProperty]
        public Lanche Lanche { get; set; }

        public Pedido Pedido { get; private set; }

        public async Task OnPostAsync() 
        {            
            var lan = await _lancheService.Obter(Lanche.Id);
            var ings = await _lancheService.ListarIngredientes();

            lan.Ingredientes.Clear();
            foreach(var ing in ings)
            {
                var ingrediente = Lanche.Ingredientes.Where(w => w.Id == ing.Id && w.Quantidade > 0).FirstOrDefault();

                if (ingrediente != null)
                {
                    ing.Quantidade = ingrediente.Quantidade;
                    lan.Ingredientes.Add(ing);
                }
            }

            var desconto = await _promocaoService.CalculaDesconto(lan);
        
            var pedido = new Pedido();

            var item = new Item() 
            {
                Descricao = lan.Nome,
                Quantidade = 1,
                Valor = lan.Total
            };

            pedido.Itens.Add(item);

            if (desconto != null)
            {
                pedido.Descontos.Add(desconto);
            }


            await _pedidoService.Criar(pedido);
            Pedido = pedido;
        }
    }
}
