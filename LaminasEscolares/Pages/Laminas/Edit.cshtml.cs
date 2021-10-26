using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaminasEscolares.Data.Repository;
using LaminasEscolares.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaminasEscolares.Pages.Laminas
{
    public class EditModel : PageModel
    {
        private IRepository _repo;
        public EditModel(IRepository repo)
        {
            _repo = repo;
        }
        [BindProperty]
        public LaminasDto lamina { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            lamina = _repo.GetPost((int) id);

            if (lamina == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (lamina.Id > 0)
                _repo.UpdatePost(lamina);
            else
                _repo.AddPost(lamina);
            if (await _repo.SaveChangesAsync())
                return RedirectToPage("Index");
            else
                return Page();
        }
    }
}
