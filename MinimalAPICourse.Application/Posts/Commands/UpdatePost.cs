using MediatR;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Application.Posts.Commands
{
    public class UpdatePost : IRequest<Post>
    {
        public int PostId { get; set; }
        public string? UpdateContent { get; set; }
    }
}
