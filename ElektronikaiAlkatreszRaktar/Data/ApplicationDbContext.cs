using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ElektronikaiAlkatreszRaktar.Models;

namespace ElektronikaiAlkatreszRaktar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ElektronikaiAlkatreszRaktar.Models.Alkatresz> Alkatresz { get; set; }
    }
}
