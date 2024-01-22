using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Cddontext : DbContext
    {
        public WebApplication2Cddontext (DbContextOptions<WebApplication2Cddontext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.Usuario> Usuario { get; set; } = default!;
    }
}
