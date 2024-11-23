using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace Library.Models.ViewModels.Book
{
    public class GetBookViewModel
    {
        public int Id { get; set; }
        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("قیمت")]
        public int? Price { get; set; }
        [DisplayName("موجودی")]
        public int Inventory { get; set; }
        [DisplayName("تعداد صفحات")]
        public int? PagesCount { get; set; }
        [DisplayName("سال انتشار")]
        public int? PublishedYear { get; set; }
        [DisplayName("شناسه ی دسته بندی")]
        public int CategoryId { get; set; }
        [DisplayName("تاریخ ایجاد")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("نام دسته بندی")]
        public string? CategoryName { get; set; }
        [DisplayName("لیست دسته بندی")]
        public List<SelectListItem>? Categories { get; set; } = new();
        [DisplayName("لیست نویسنده ها")]
        public List<SelectListItem>? Authors { get; set; } = new();
    }
}
