using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurismoReactnetCore.Models;

namespace TurismoReactnetCore.Context
{
    public class AppContext: DbContext
    {
        public AppContext(DbContextOptions<AppContext> options): base(options)
        {

        }
        public DbSet<UserTurismo> Turismo { get; set; }
        public DbSet<Compras> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compras>()
                .HasOne(p => p.UserTurismo)
                .WithMany(b => b.Compras)
                .HasForeignKey(p => p.FK_Turismo)
            .OnDelete(DeleteBehavior.Cascade);
        }



    }
}
