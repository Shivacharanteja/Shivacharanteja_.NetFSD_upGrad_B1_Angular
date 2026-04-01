﻿using EntityFrameworkAssignment1.Entities;
using Microsoft.EntityFrameworkCore;
namespace EntityFrameworkAssignment1.DataBase
{
    public class AppDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18, 2);
        }
    }
}
