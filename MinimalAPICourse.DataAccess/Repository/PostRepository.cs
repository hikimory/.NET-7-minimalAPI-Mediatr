using Microsoft.EntityFrameworkCore;
using MinimalAPICourse.Application.Abstractions;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _ctx;
        public PostRepository(SocialDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Post> CreatePost(Post toCreate)
        {
            if(toCreate != null)
            {
                toCreate.DateCreated = DateTime.Now;
                toCreate.LastModified = DateTime.Now;
                _ctx.Posts.Add(toCreate);
                await _ctx.SaveChangesAsync();
            }
            return toCreate;
        }

        public async Task DeletePost(int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (post != null)
            {
                _ctx.Posts.Remove(post);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<Post> GetPostbyId(int postId)
        {
            return await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<ICollection<Post>> GetPosts()
        {
            return await _ctx.Posts.ToListAsync();
        }

        public async Task<Post> UpdatePost(string updateContent, int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (post != null)
            {
                post.Content = updateContent;
                post.LastModified = DateTime.Now;
                await _ctx.SaveChangesAsync();
            }
            return post;
        }
    }
}
