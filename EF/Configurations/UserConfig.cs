using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);
            entity.ToTable(TablesName.User);
            entity.Property(e => e.Id)
                .HasMaxLength(User.IdLength)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(User.EmailLength);
            entity.Property(e => e.Pwd)
                .HasMaxLength(User.PwdLength);
        }
    }
}