using System.ComponentModel.DataAnnotations;
namespace CoreBackend.Controllers.Content
{
    public class ContentTypeRequest
    {
        [Required(ErrorMessage = "ContentType is required")]
        [RegularExpression("^(NEWS|PROMO)$", ErrorMessage = "ContentType must be either NEWS or PROMO")]
        public string? ContentType { get; set; }
    }
}
