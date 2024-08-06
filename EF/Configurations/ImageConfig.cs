using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");
            builder.ToTable(TablesName.Image);
            builder.HasIndex(e => e.ProductId, "IDX_imageID");
            builder.HasIndex(e => e.ImageDsc, "IDX_imageName");
            builder.Property(e => e.ImageDsc)
                .HasMaxLength(50);
            builder.Property(e => e.ImageUrl)
                .HasColumnType("text");
            builder.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsFixedLength();
            builder.HasOne(d => d.Product).WithMany(p => p.TblImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_image_product");
            builder.HasOne(d => d.Variant).WithMany(p => p.Images)
               .HasForeignKey(d => d.VariantId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_image_variant");
        }
    }
}