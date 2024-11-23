using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Library.Models.ViewModels.Author
{
    public class IndexAuthorViewModel
    {
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("نام خانوادگی")]
        public string? LastName { get; set; }
        [DisplayName("تاریخ تولد")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("تاریخ ایجاد")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("لیست کتاب ها")]
        public List<SelectListItem>? Books { get; set; } = new();
    }
}
