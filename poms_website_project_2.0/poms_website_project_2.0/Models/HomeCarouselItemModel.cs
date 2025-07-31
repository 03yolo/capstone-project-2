using System.ComponentModel.DataAnnotations;

namespace poms_website_project_2._0.Models
{
    public class HomeCarouselItemModel
    {
        [Key]
        public int CarouselItemId { get; set; }

        public string ImagePath { get; set; } = null!;

        public string? CaptionTitle { get; set; }

        public string? CaptionText { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public int UploadedBy { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
