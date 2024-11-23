using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.ViewModels.Book
{
    public class CreateBookViewModel
    {
        [DisplayName("نام")]
        [Required(ErrorMessage="نام کتاب اجباری می باشد")]
        public string Name { get; set; }
        [DisplayName("قیمت")]
        public int? Price { get; set; }
        [DisplayName("موجودی")]
        public int Inventory { get; set; }
        [DisplayName("تعداد صفحات")]
        public int? PagesCount { get; set; }
        [DisplayName("سال انتشار")]
        public int? PublishedYear { get; set; }
        [DisplayName("دسته بندی")]
        public int CategoryId { get; set; }
        public List<int> AuthorIds { get; set; } = new();

        [DisplayName("لیست دسته بندی")]
        public List<SelectListItem>? Categories { get; set; } = new();

        [DisplayName("لیست نویسنده ها")]
        public List<SelectListItem>? Authors { get; set; } = new();
    }
}
