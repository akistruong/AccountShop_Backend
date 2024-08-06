using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.VariantId }).HasName("PRIMARY");
            builder.ToTable(TablesName.OrderDetail);
            builder.HasIndex(e => e.VariantId, "IDX_Ordt_variant");
            builder.HasIndex(e => e.OrderId, "IX_orderdetail_order_id");
            builder.HasIndex(e => new { e.VariantId, e.OrderId }, "IX_OrderDetail");
            builder.Property(e => e.OrderId);
            builder.Property(e => e.VariantId);
            builder.Property(e => e.OdtPrice)
                .HasPrecision(10)
                .HasColumnName("odt_price");
            builder.Property(e => e.OdtQty);
            builder.HasOne(d => d.Order).WithMany(p => p.Orderdetails)

                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orderdt_order");
            builder.HasOne(d => d.Variant).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orderdt_variant");
        }
    }
}