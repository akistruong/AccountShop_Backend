using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AccountShop.Models;

public partial class AccountShopContext : DbContext
{
    public AccountShopContext()
    {
    }

    public AccountShopContext(DbContextOptions<AccountShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=123456;database=AccountShop");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PRIMARY");

            entity.ToTable("orderdetail");

            entity.HasIndex(e => e.ProductId, "fk_orderdt_product");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.OdtPrice)
                .HasPrecision(10)
                .HasColumnName("odt_price");
            entity.Property(e => e.OdtQty).HasColumnName("odt_qty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
