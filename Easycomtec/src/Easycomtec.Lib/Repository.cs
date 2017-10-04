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
        
        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>().AsQueryable();
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

        public IRepository RemoveItem<T>(T item) 
            where T : class, IObject
        {
            if (this.Entry(item).State == EntityState.Detached)
                this.Attach(item);
            this.Set<T>().Remove(item);
            return this;
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
