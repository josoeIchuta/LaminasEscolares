using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaminasEscolares.Data.Repository;
using LaminasEscolares.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LaminasEscolares.Pages.Laminas
{
    public class IndexModel : PageModel
    {
        private IRepository _repo;
        public IndexModel(IRepository repo)
        {
            _repo = repo;
        }
        [BindProperty]
        public IList<LaminasDto> postLaminas { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty]
        public LaminasDto lamina { get; set; }

        public string dataJson;

        public IActionResult OnGet()
        {
            postLaminas = _repo.GetSearchPost(SearchString).ToList();
            //postLaminas = _repo.GetAllPosts();
            dataJson = JsonConvert.SerializeObject(postLaminas);
            return Page();
        }
        public async Task<IActionResult> OnGetRemove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        //Este Metodo deberia ser POST lo solucione cargando Nuevamente la Pagina, pero no esta bien porque 
        //Es como si entrara de nuevo
        //Osea que si filtro y aumento, NO vere lo que aumente SINO lo pagina de INICIO
        public async Task<IActionResult> OnGetSumarCantidad(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            lamina = _repo.GetPost((int)id);

            if (lamina == null)
            {
                return NotFound();
            }
            lamina.Cantidad += 1;
            _repo.UpdatePost(lamina);
            await _repo.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnGetRestarCantidad(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            lamina = _repo.GetPost((int)id);

            if (lamina == null)
            {
                return NotFound();
            }

            if (lamina.Cantidad > 0)
                lamina.Cantidad -= 1;

            _repo.UpdatePost(lamina);
            await _repo.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
