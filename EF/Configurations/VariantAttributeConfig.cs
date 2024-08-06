using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class VariantAttributeConfig : IEntityTypeConfiguration<VariantAttribute>
    {
        public void Configure(EntityTypeBuilder<VariantAttribute> builder)
        {
            builder.HasKey(e => new { e.VariantId, e.OptionValueID }).HasName("PRIMARY");
            builder.ToTable(TablesName.VariantAttribute);
            builder.HasIndex(e => e.VariantId, "IX_variant_attribute_VariantId");
            builder.HasIndex(e => e.OptionValueID, "IX_optionvalue_attribute_OptionValueID");
            builder.HasOne(d => d.Variant).WithMany(p => p.VariantAttributes)
                .HasForeignKey(d => d.VariantId)
                .HasConstraintName("fk_attribute_variant");
            builder.HasOne(d => d.OptionValue).WithMany(p => p.VariantAttributes)
                .HasForeignKey(d => d.OptionValueID)
                .HasConstraintName("fk_attribute_optionvalue");
        }
    }
}