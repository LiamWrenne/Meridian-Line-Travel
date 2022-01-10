using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Meridian_Line_Travel.Models;
using Meridian_Line_Travel.Areas.Admin.Models;

namespace Meridian_Line_Travel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Meridian_Line_Travel.Models.Planes> Planes { get; set; }
        public DbSet<Meridian_Line_Travel.Areas.Admin.Models.AdminModel> Admin { get; set; }
    }
}
