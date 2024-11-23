using Library.Models.ViewModels.Book;
using System.ComponentModel;

namespace Library.Models.ViewModels.Category
{
    public class GetCategoryViewModel
    {
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("رده ی سنی")]
        public string? AgeGroup { get; set; }
        [DisplayName("تاریخ ایجاد")]
        public DateTime CreatedDate { get; set; }
        
        [DisplayName("کتاب ها")]
        public List<IndexBookViewModel>? Books { get; set; } = new();
    }
}
