using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromocaoAPI.Models;
using PromocaoAPI.Models.Repositories;
using System.Threading;

namespace PromocaoAPI.Controllers
{
    [Route("calcula-desconto")]
    public class CalculaDescontoController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly ICalculaValor _calculaValor;
        public CalculaDescontoController(IUnitOfWork uow, ICalculaValor calculaValor)
        {
            _uow = uow;
            _calculaValor = calculaValor;
        }

        // POST api/values
        [HttpPost]
        public async Task<Desconto> Post([FromBody]Lanche value)
        {
            var promocao = await _uow.PromocaoRepository.Get(value.Nome);

            if (promocao == null)
            {
                return null;
            }

            var valor = CalculaValor(value, promocao);

            if (valor == 0m)
            {
                return null;
            }

            var desconto = new Desconto
            {
                Descricao = promocao.Nome,
                Valor = valor
            };

            return desconto;
        }

        private decimal CalculaValor(Lanche lanche, Promocao promocao) 
        {
            switch(promocao.Nome)
            {
                case "Light":
                    return _calculaValor.Light(lanche);
                case "Muita carne":
                    return _calculaValor.Carne(lanche);
                case "Muito queijo":
                    return _calculaValor.Queijo(lanche);
                default:
                    return 0;
            }
        }
    }
}
