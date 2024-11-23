using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.ViewModels.Author
{
    public class UpdateAuthorViewModel
    {
        [DisplayName("شناسه")]
        public int Id { get; set; }
        [DisplayName("نام")]
        [Required(ErrorMessage="نام نویسنده اجباری می باشد")]
        public string Name { get; set; }
        [DisplayName("نام خانوادگی")]
        public string? LastName { get; set; }
        [DisplayName("تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("لیست کتاب ها")]
        public List<SelectListItem>? Books { get; set; } = new();
    }
}
