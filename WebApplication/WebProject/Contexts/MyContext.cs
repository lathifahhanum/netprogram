using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Contexts
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {

        }

        //mendaftarkan model ke dalam context/database
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<Universities> Universities { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relasi antra satu uni dg byk edu
            modelBuilder.Entity<Universities>()
                .HasMany(u => u.Educations)
                .WithOne(e => e.Universities)
                .HasForeignKey(u => u.UniversityId);

            //cara lain
            /*modelBuilder.Entity<Educations>()
                .HasOne(e => e.Universities)
                .WithMany(u => u.Educations)
                .HasForeignKey(e => e.UniversityId);*/
        }
    }
}
