using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");
            builder.ToTable(TablesName.Category);

            builder.HasIndex(e => e.CategoryName, "idx_category");

            builder.Property(e => e.CategoryImage)
                .HasColumnType("text");
            builder.Property(e => e.CategoryName)
                .HasMaxLength(50);
            builder.Property(e => e.CategoryRootId);

            builder.HasOne(d => d.CategoryRoot).WithMany(p => p.InverseCategoryRoot)
                .HasForeignKey(d => d.CategoryRootId)
                .HasConstraintName("fk_category");
        }
    }
}