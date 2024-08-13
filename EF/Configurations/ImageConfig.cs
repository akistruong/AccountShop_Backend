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
            builder.HasKey(e => e.Id);
            builder.ToTable(TablesName.Image);
            builder.Property(e => e.ImageDsc)
                .HasMaxLength(50);
            builder.Property(e => e.ImageUrl)
                .HasColumnType("text");
            builder.Property(e => e.ProductId);
            builder.HasOne(d => d.Variant).WithMany(p => p.Images)
               .HasForeignKey(d => d.VariantId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_image_variant");
        }
    }
}