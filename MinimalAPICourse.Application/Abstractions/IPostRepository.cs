using MinimalAPICourse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalAPICourse.Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetPosts();
        Task<Post> GetPostbyId(int postId);
        Task<Post> CreatePost(Post toCreate);
        Task<Post> UpdatePost(string updateContent, int postId);
        Task DeletePost(int postId);

    }
}
