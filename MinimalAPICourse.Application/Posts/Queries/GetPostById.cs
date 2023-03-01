using MediatR;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Application.Posts.Queries
{
    public class GetPostById : IRequest<Post>
    {
        public int PostId { get; set; }
    }
}
