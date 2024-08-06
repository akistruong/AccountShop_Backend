using AccountShop.Const;
using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entity)
        {
            entity.HasKey(e => e.Id);
            entity.ToTable(TablesName.Branch);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.BranchName);
            entity.Property(e => e.BranchDsc);
        }
    }
}