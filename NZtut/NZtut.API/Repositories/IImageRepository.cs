using NZtut.API.Models.Domain;

namespace NZtut.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadImageAsync(Image image);
        //Task<Image> GetImageByIdAsync(Guid id);
        //Task<IEnumerable<Image>> GetAllImagesAsync();
        //Task DeleteImageAsync(Guid id);
        //Task UpdateImageAsync(Image image);
    }
}
