using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestauranteApi.Datos.Models;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=prueba;uid=root;password=Mario12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PRIMARY");

            entity.ToTable("Customer");

            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(45)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroCelular).HasColumnName("numero_celular");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorder).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.CustomerId, "fk_customer_order_idx");

            entity.Property(e => e.Idorder).HasColumnName("idorder");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.NumeroOrder)
                .HasMaxLength(45)
                .HasColumnName("numero_order");
            entity.Property(e => e.ProductoName)
                .HasMaxLength(45)
                .HasColumnName("producto_name");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_order");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
