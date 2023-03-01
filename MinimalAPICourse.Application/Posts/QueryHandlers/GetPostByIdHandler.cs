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
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository _postRepository;
        public GetPostByIdHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetPostbyId(request.PostId);
        }
    }
}
