using Library.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.LastName).IsRequired(false).HasDefaultValue(string.Empty);
            builder.Property(c => c.BirthDate).IsRequired(false).HasDefaultValue(default(DateTime));
            builder.Property(c => c.CreatedDate).IsRequired(true);
        }
    }
}
