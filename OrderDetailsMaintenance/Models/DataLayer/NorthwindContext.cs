using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace OrderDetailsMaintenance.Models.DataLayer;

public partial class NorthwindContext : DbContext
{
    // Estevao Previatti
    public NorthwindContext()
    {
    }

    // Estevao Previatti
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    // Estevao Previatti
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            var conn = ConfigurationManager.ConnectionStrings["Northwind"]?.ConnectionString;
            if (string.IsNullOrEmpty(conn))
            {
              
                conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Northwind.mdf;Integrated Security=True";
            }

            optionsBuilder.UseSqlServer(conn);
        }
    }

    // Estevao Previatti
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    // Estevao Previatti
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
