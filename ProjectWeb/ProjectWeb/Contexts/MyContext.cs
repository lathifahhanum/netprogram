using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProjectWeb.Models;
using ProjectWeb.ViewModels;

namespace ProjectWeb.Contexts
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {

        }

        //mendaftarkan model ke dalam context/database
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Role> Roles { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relasi antra satu uni dg byk edu
            modelBuilder.Entity<University>()
                .HasMany(u => u.Educations)
                .WithOne(e => e.Universities)
                .HasForeignKey(u => u.UniversityId);

            //cara lain
            /*modelBuilder.Entity<Educations>()
                .HasOne(e => e.Universities)
                .WithMany(u => u.Educations)
                .HasForeignKey(e => e.UniversityId);*/

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Profilings)
                .WithOne(p => p.Employees)
                .HasForeignKey<Profiling>(e => e.EmployeeNik);

            modelBuilder.Entity<Education>()
                .HasOne(e => e.Profilings)
                .WithOne(p => p.Educations)
                .HasForeignKey<Profiling>(e => e.EducationId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Accounts)
                .WithOne(a => a.Employees)
                .HasForeignKey<Account>(e => e.EmployeeNik);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.AccountRoles)
                .WithOne(ar => ar.Roles)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(ar => ar.Accounts)
                .HasForeignKey(a => a.AccountNik);

            modelBuilder.Entity<RegisterVM>()
                .HasNoKey();

            modelBuilder.Entity<LoginVM>()
                .HasNoKey();
        }

        //Fluent API
        public DbSet<ProjectWeb.ViewModels.LoginVM>? LoginVM { get; set; }
    }
}
