using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersFinal.Model
{
    public class Number
    {
        [Key]
        public int Id { get; set; }

        
        public string StringNumber { get; set; }

    }
}
