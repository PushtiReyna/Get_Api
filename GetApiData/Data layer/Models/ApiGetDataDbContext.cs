using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data_layer.Models;

public partial class ApiGetDataDbContext : DbContext
{
    public ApiGetDataDbContext()
    {
    }

    public ApiGetDataDbContext(DbContextOptions<ApiGetDataDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiGetDataMst> ApiGetDataMsts { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=ApiGetDataDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiGetDataMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiGetDa__3214EC07B95E0377");

            entity.ToTable("ApiGetDataMst");

            entity.Property(e => e.AdjHigh).HasColumnName("adj_high");
            entity.Property(e => e.AdjLow).HasColumnName("adj_low");
            entity.Property(e => e.High).HasColumnName("high");
            entity.Property(e => e.Low).HasColumnName("low");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
