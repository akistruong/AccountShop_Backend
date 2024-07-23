using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(Product.IdLength);
            builder.Property(x => x.ProductName).HasMaxLength(Product.NameLength);
            builder.ToTable(TablesName.Product);
            builder.HasOne(d => d.Category).WithMany(p => p.Products)
             .HasForeignKey(d => d.CategoryId)
             .HasConstraintName("fk_product_category");
            builder.HasOne(d => d.Root).WithMany(p => p.InverseRoot)
                .HasForeignKey(d => d.RootId)
                .HasConstraintName("fk_product_root");
        }
    }
}