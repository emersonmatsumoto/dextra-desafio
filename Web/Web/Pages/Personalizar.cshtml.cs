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
    public class PersonalizarModel : PageModel
    {
        private readonly ILancheService _lancheService;

        public PersonalizarModel(ILancheService lancheService)
        {
            _lancheService = lancheService;
        }

        [BindProperty]
        public int compra { get; set; }
        public Lanche Lanche { get; private set; }
        public IList<Ingrediente> Ingredientes { get; private set; }
        //  public async Task<IActionResult> OnPostAsync() //(2)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return Page();
        //     }
        
        //     //Some logic here…
        
        //     return RedirectToPage();
        // }
        public async Task OnPostAsync()
        {            
            Lanche = await _lancheService.Obter(compra);
            Ingredientes = await _lancheService.ListarIngredientes();
            var defaultIngrediente = new Ingrediente { Quantidade = 0 };

            Ingredientes = Ingredientes.GroupJoin(Lanche.Ingredientes,
                                i => i.Nome,
                                o => o.Nome,
                                (i,o) => new {i = i, o = o.DefaultIfEmpty(defaultIngrediente)})
                            .Select(s => new  Ingrediente {
                                Id = s.i.Id,
                                Nome = s.i.Nome,
                                Valor = s.i.Valor,
                                Quantidade = s.o.Select(m => m.Quantidade).FirstOrDefault()
                            })
                            .ToList();
        }
    }
}
