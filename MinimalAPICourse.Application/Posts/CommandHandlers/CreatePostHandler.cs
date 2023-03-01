using MediatR;
using MinimalAPICourse.Application.Abstractions;
using MinimalAPICourse.Application.Posts.Commands;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postRepository;
        public CreatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        async Task<Post> IRequestHandler<CreatePost, Post>.Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.PostContent
            };
            return await _postRepository.CreatePost(newPost);
        }
    }
}
