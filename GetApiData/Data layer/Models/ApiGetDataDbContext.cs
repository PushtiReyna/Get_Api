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

    public virtual DbSet<TimezoneMst> TimezoneMsts { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=ApiGetDataDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TimezoneMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Timezone__3214EC07A1ADBEA6");

            entity.ToTable("TimezoneMst");

            entity.Property(e => e.Field)
                .IsUnicode(false)
                .HasColumnName("field");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
