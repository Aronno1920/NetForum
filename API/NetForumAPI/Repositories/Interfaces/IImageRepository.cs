using NetForumAPI.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace NetForumAPI.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
        Task<IEnumerable<BlogImage>> GetAll();
    }
}
