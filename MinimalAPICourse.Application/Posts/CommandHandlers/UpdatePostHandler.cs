using MediatR;
using MinimalAPICourse.Application.Abstractions;
using MinimalAPICourse.Application.Posts.Commands;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Application.Posts.CommandHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostRepository _postRepository;
        public UpdatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        async Task<Post> IRequestHandler<UpdatePost, Post>.Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.UpdatePost(request.UpdateContent, request.PostId);
            return post;
        }
    }
}
