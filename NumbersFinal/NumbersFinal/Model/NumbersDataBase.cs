using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersFinal.Model
{
    public class NumbersDataBase : DbContext
    {
        public NumbersDataBase(DbContextOptions<NumbersDataBase> options) : base(options)
        {

        }

        public DbSet<Number> numberClasses { get; set; }


    }
}
