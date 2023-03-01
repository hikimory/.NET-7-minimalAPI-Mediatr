using MediatR;
using MinimalAPICourse.Application.Abstractions;
using MinimalAPICourse.Application.Posts.Commands;

namespace MinimalAPICourse.Application.Posts.CommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postRepository;
        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postRepository.DeletePost(request.PostId);
        }
    }
}
