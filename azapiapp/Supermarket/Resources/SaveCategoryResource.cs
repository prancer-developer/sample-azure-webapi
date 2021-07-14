using System.ComponentModel.DataAnnotations;

namespace azapiapp.Supermarket.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}