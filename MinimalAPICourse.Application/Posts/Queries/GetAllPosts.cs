using MediatR;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Application.Posts.Queries
{
    public class GetAllPosts : IRequest<ICollection<Post>>
    {
    }
}
