using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TodoItem>()
            .HasOne(t => t.WebAppUser)
            .WithMany(u => u.TodoItems)
            .HasForeignKey(t => t.WebAppUserId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
