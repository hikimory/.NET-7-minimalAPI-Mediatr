using MediatR;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Application.Posts.Commands
{
    public class CreatePost : IRequest<Post>
    {
        public string? PostContent { get; set; }
    }
}
