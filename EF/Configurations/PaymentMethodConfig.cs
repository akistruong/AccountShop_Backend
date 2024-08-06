using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable(TablesName.PaymentMethod);

            entity.Property(e => e.MethodDsc)
                .HasColumnType("text");
            entity.Property(e => e.MethodName)
                .HasMaxLength(30);
        }
    }
}