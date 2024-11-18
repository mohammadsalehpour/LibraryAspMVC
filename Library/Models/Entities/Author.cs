namespace Library.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }



        public List<AuthorBook>? AuthorBooks { get; set; }
    }
}
