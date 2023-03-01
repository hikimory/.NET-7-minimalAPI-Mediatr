using MediatR;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Application.Posts.Commands
{
    public class DeletePost : IRequest
    {
        public int PostId { get; set; }
    }
}
