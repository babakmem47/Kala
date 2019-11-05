using System.Data.Entity.ModelConfiguration;

namespace Kala.EntityConfigurations
{
    public class KalaConfiguration : EntityTypeConfiguration<Models.Kala>
    {
        public KalaConfiguration()
        {
            Property(k => k.Name)
                .HasMaxLength(255);
            Property(k => k.Model)
                .HasMaxLength(255);
            Property(k => k.Color)
                .HasMaxLength(20);
            
        }
    }
}