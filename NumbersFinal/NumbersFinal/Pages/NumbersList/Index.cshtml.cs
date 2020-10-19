using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NumbersFinal.Model;

namespace NumbersFinal.Pages.NumbersList
{
    public class IndexModel : PageModel
    {

        private readonly NumbersDataBase _db;

        public IndexModel(NumbersDataBase db)
        {
            _db = db;
        }

        public IEnumerable<Number> NumberClasses { get; set; }

        public async Task OnGet()
        {
            NumberClasses = await _db.numberClasses.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var number = await _db.numberClasses.FindAsync(id);
            if (number == null)
            {
                return NotFound();
            }

            _db.numberClasses.Remove(number);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }


    }
}

