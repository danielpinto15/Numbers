using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NumbersFinal.Model;

namespace NumbersFinal.Pages.NumbersList
{
    public class CreateModel : PageModel
    {

        private readonly NumbersDataBase _db;

        public CreateModel(NumbersDataBase db)
        {
            _db = db;
        }

        [BindProperty]
        public Number number { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await _db.numberClasses.AddAsync(number);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
