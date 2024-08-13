using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class OptionConfig : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.OptionName);
            builder.ToTable(TablesName.Option);
            builder.HasOne(d => d.Product).WithMany(p => p.Options)
               .HasForeignKey(d => d.ProductID)
               .HasConstraintName("fk_option_product");
        }
    }
}