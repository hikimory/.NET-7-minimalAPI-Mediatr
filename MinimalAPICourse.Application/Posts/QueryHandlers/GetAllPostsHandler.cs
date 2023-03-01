using MediatR;
using MinimalAPICourse.Application.Abstractions;
using MinimalAPICourse.Application.Posts.Commands;
using MinimalAPICourse.Application.Posts.Queries;
using MinimalAPICourse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalAPICourse.Application.Posts.QueryHandlers
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {
        private readonly IPostRepository _postRepository;
        public GetAllPostsHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetPosts();
        }
    }
}
