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

    public virtual DbSet<Datum> Data { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=ApiGetDataDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Datum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AdjClose).HasColumnName("adj_close");
            entity.Property(e => e.AdjHigh).HasColumnName("adj_high");
            entity.Property(e => e.AdjLow).HasColumnName("adj_low");
            entity.Property(e => e.AdjOpen).HasColumnName("adj_open");
            entity.Property(e => e.AdjVolume).HasColumnName("adj_volume");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Dividend).HasColumnName("dividend");
            entity.Property(e => e.Exchange).HasColumnName("exchange");
            entity.Property(e => e.High).HasColumnName("high");
            entity.Property(e => e.Low).HasColumnName("low");
            entity.Property(e => e.SplitFactor).HasColumnName("split_factor");
            entity.Property(e => e.StockClose).HasColumnName("stock_close");
            entity.Property(e => e.StockOpen).HasColumnName("stock_open");
            entity.Property(e => e.Symbol).HasColumnName("symbol");
            entity.Property(e => e.Volume).HasColumnName("volume");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
