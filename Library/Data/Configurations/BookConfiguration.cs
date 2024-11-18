using Library.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.Price).IsRequired(false).HasDefaultValue(default);
            builder.Property(c => c.Inventory).IsRequired(true);
            builder.Property(c => c.PagesCount).IsRequired(false).HasDefaultValue(default);
            builder.Property(c => c.PublishedYear).IsRequired(false).HasDefaultValue(default);
            builder.Property(c => c.CategoryId).IsRequired(true);
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.HasOne(c => c.Category).WithMany(c => c.Books).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

