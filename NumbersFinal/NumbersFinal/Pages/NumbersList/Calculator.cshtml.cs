using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NumbersFinal.Model;
using Org.BouncyCastle.Crypto.Tls;
using Prism.Services.Dialogs;
using Xceed.Wpf.Toolkit;

namespace NumbersFinal.Pages.NumbersList
{
    public class CalculatorModel : PageModel
    {
        private readonly NumbersDataBase _db;

        public CalculatorModel(NumbersDataBase db)
        {
            _db = db;
        }

        [BindProperty]
        public Number number { get; set; }

        [BindProperty]
        public MathsCalc MathsCalc { get; set; }

        
        public IEnumerable<Number> NumberClasses { get; set; }

        public async Task OnGet()
        {
            if (NumberClasses == null)
            {
                NumberClasses = await _db.numberClasses.ToListAsync();
            }

            if (MathsCalc == null)
            {
                MathsCalc = new MathsCalc();

            }
            

        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {

                string input = MathsCalc.numbersToSplit;
                string pattern = "[^\\w']+";            
                string[] numbersArray = Regex.Split(input, pattern);

                foreach (string id in numbersArray)
                {
                        int idNumber = Convert.ToInt32(id);
                        Number numb = _db.numberClasses.Find(idNumber);
                        if (numb == null)
                        {
                            MathsCalc.Result = 0;
                            
                            RedirectToPage("Error");
                        }
                        else
                        {
                            MathsCalc.Result += Convert.ToDouble(numb.StringNumber, System.Globalization.CultureInfo.InvariantCulture);
                        }

                }
            }

            

            if (NumberClasses == null)
            {
                NumberClasses = await _db.numberClasses.ToListAsync();
            }

            Page();
        }
    }
}
