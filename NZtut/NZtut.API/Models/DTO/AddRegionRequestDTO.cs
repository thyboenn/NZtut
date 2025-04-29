using System.ComponentModel.DataAnnotations;

namespace NZtut.API.Models.DTO
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 chars")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 chars")]
        public string Code { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Name has to be a minimum of 1 chars")]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 chars")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
