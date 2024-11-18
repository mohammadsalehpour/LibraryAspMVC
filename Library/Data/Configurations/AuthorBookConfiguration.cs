using Library.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configurations
{
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.ToTable("author_books");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AuthorId).IsRequired(true);
            builder.Property(c => c.BookId).IsRequired(true);

            builder.HasOne(c => c.Author).WithMany(c => c.AuthorBooks).HasForeignKey(c => c.AuthorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Book).WithMany(c => c.AuthorBooks).HasForeignKey(c => c.BookId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
