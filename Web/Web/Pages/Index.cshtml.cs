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
    public class IndexModel : PageModel
    {
        private readonly ILancheService _lancheService;

        public IndexModel(ILancheService lancheService)
        {
            _lancheService = lancheService;
        }

        public IList<Lanche> Lanches { get; private set; }
        public async Task OnGet()
        {
            Lanches = await _lancheService.Listar();
            // Lanches = new List<Lanche>{
            //     new Lanche {
            //         Nome = "X-Bacon",
            //         Ingredientes = new List<Ingrediente>{
            //             new Ingrediente{
            //                 Nome = "Alface",
            //                 Quantidade = 1,
            //                 Valor = 0.8m
            //             },
            //             new Ingrediente{
            //                 Nome = "Hambúrger de carne",
            //                 Quantidade = 1,
            //                 Valor = 0.8m
            //             },
            //             new Ingrediente{
            //                 Nome = "Bacon",
            //                 Quantidade = 1,
            //                 Valor = 0.8m
            //             },
            //             new Ingrediente{
            //                 Nome = "Queijo",
            //                 Quantidade = 1,
            //                 Valor = 0.8m
            //             },
            //         }
            //     }

            // };
        }
    }
}
