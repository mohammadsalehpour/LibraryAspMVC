using System.ComponentModel;

namespace Library.Models.ViewModels
{
    public class IndexBookViewModel
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
        [DisplayName("دسته بندی")]
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }



        public string? CategoryName { get; set; }
    }
}
