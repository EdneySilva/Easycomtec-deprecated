using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Easycomtec.Lib
{
    public class Repository : DbContext, IRepository
    {
        internal DbSet<Candidate> Candidate { get; set; }
        internal DbSet<Address> Address { get; set; }
        internal DbSet<Account> Account { get; set; }
        internal DbSet<Skill> Skill { get; set; }
        internal DbSet<Phone> Phone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasOne(p => p.Account)
                .WithOne(p => p.Candidate)
                .HasForeignKey<Account>(c => c.Id);
            base.OnModelCreating(modelBuilder);
        }

        public IRepository For<T>(T teste)
        {
            
            return this;
        }

        public IRepository AddOrUpdate<T>(T item) where T : class, IObject
        {
            try
            {                
                var entry = this.Entry<T>(item);
                if (!entry.IsKeySet)
                    this.Set<T>().Add(item);
                else
                    this.Set<T>().Update(item);
            }
            catch (Exception ex)
            {

            }
            return this;
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
