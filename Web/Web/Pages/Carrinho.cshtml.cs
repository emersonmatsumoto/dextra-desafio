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

        public CarrinhoModel(ILancheService lancheService)
        {
            _lancheService = lancheService;
        }

        [BindProperty]
        public Lanche Lanche { get; set; }

        public async Task<IActionResult> OnPostAsync() //(2)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            
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

            
        
            //Some logic here…
        
            return RedirectToPage();
        }
    }
}
