namespace Library.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int Inventory { get; set; }
        public int? PagesCount { get; set; }
        public int? PublishedYear { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}
