using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZtut.API.Models.Domain;
using NZtut.API.Models.DTO;
using NZtut.API.Repositories;

namespace NZtut.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //POST - to upload image
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                // Convert DTO to domain model
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };

                // Save the file to the server through repository
                await imageRepository.UploadImageAsync(imageDomainModel);
                return Ok(imageDomainModel);

            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDTO request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png"};

            if (allowedExtensions.Contains(Path.GetExtension(request.File.FileName).ToLower()) == false)
            {
                ModelState.AddModelError("File", "Invalid file type. Only .jpg, .jpeg, and .png are allowed.");
            }

            if (request.File.Length > 10 * 1024 * 1024) // 10 MB
            {
                ModelState.AddModelError("File", "File size exceeds the limit of 10 MB.");
            }
        }
    }
}
