using NetForumAPI.Data;
using NetForumAPI.Models.Domain;
using NetForumAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NetForumAPI.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDBContext dBContext;

        public BlogPostRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dBContext.BlogPosts.AddAsync(blogPost);
            await dBContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await dBContext.BlogPosts.Include(x => x.Categories).ToListAsync();
        }

        public async Task<BlogPost?> GetByIdAsync(Guid id)
        {
            return await dBContext.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await dBContext.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await dBContext.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            
            if (existingBlogPost == null) { 
                return null;
            }

            // Update BlogPost
            dBContext.Entry(existingBlogPost).CurrentValues.SetValues(blogPost);
             
            // Update Categories
            existingBlogPost.Categories = blogPost.Categories;

            await dBContext.SaveChangesAsync();

            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlogPost = await dBContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingBlogPost != null) 
            {
                dBContext.BlogPosts.Remove(existingBlogPost);
                await dBContext.SaveChangesAsync();
                return existingBlogPost; 
            }

            return null;
        }
    }
}
