namespace Library.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? AgeGroup { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public required List<Book> Books { get; set; }
    }

}
