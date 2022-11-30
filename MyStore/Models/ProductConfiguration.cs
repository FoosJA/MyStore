using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyStore.Models
{
    public class ProductConfiguration: IEntityTypeConfiguration<ProductClass>
    {
        public void Configure(EntityTypeBuilder<ProductClass> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(t => t.ProductID);
            
        }
    }
}
