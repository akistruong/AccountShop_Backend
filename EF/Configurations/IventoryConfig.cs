using AccountShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountShop.EF.Configurations
{
    public class IventoryConfig : IEntityTypeConfiguration<Iventory>
    {
        public void Configure(EntityTypeBuilder<Iventory> entity)
        {
            entity.HasKey(e => new { e.ProductID, e.BranchID });
            entity.HasOne(d => d.Product).WithMany(p => p.Iventories)
             .HasForeignKey(d => d.ProductID)
             .HasConstraintName("fk_Iventory_product");
            entity.HasOne(d => d.Branch).WithMany(p => p.Iventories)
            .HasForeignKey(d => d.BranchID)
            .HasConstraintName("fk_Iventory_branch");
        }
    }
}