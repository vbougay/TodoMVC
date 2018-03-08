using System;
using Microsoft.EntityFrameworkCore;
using TodoMVC.Models;

namespace TodoMVC
{
    public class TodoContext: DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().Property(e => e.Complete).HasDefaultValue(false);
        }

        public TodoContext(DbContextOptions<TodoContext> options):
            base(options)
        {
        }

        public DbSet<TodoItem> Items { get; set; }
    }
}
