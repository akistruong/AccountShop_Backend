using AccountShop.Const;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class OptionValue : IEntityTypeConfiguration<AccountShop.Entities.OptionValue>
    {
        public void Configure(EntityTypeBuilder<AccountShop.Entities.OptionValue> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.Property(e => e.OptionValueName);
            entity.ToTable(TablesName.OptionValue);
            entity.HasOne(d => d.Option).WithMany(p => p.OptionValues)
               .HasForeignKey(d => d.OptionID)
               .HasConstraintName("fk_optionvalue_option");
        }
    }
}