using Microsoft.EntityFrameworkCore;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Persistance.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<ItemsOrdered>()
                .HasKey(io => io.Id);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
            modelBuilder.Entity<ItemsOrdered>
                (io =>
                {
                    io.HasOne(i => i.Item)
                    .WithMany(i => i.ItemsOrdered)
                    .HasForeignKey(i => i.ItemID);
                    io.HasOne(o => o.Order)
                    .WithMany(o => o.ItemsOrdered)
                    .HasForeignKey(o => o.OrderID);
                });
        }
    }
}
