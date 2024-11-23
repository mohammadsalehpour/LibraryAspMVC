using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [DisplayName("نام")]
        [Required(ErrorMessage="نام دسته بندی اجباری می باشد")]
        public string Name { get; set; }
        [DisplayName("رده ی سنی")]
        public string? AgeGroup { get; set; }
    }
}
