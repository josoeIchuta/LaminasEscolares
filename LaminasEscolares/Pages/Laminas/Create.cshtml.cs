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
    public class CreateModel : PageModel
    {
        private IRepository _repo;
        public CreateModel(IRepository repo)
        {
            _repo = repo;
        }
        [BindProperty]
        public LaminasDto Lamina { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostCreate()
        {
            _repo.AddPost(Lamina);

            if (await _repo.SaveChangesAsync())
                return RedirectToPage("Index");
            else
                return Page();
        }
    }
}
