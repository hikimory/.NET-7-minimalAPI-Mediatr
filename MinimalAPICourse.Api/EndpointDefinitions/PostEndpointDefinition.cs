using MediatR;
using Microsoft.Extensions.Hosting;
using MinimalAPICourse.Api.Abstractions;
using MinimalAPICourse.Api.Filters;
using MinimalAPICourse.Application.Posts.Commands;
using MinimalAPICourse.Application.Posts.Queries;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Api.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");

            posts.MapGet("/{id}", GetPostById).WithName(nameof(GetPostById));
            posts.MapPost("/", CreatePost).AddEndpointFilter<PostValidationFilter>();
            posts.MapGet("/", GetPosts);
            posts.MapPut("/{id}", UpdatePost).AddEndpointFilter<PostValidationFilter>(); ;
            posts.MapDelete("/{id}", DeletePost);
        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var getPost = new GetPostById { PostId = id };
            var post = await mediator.Send(getPost);
            return TypedResults.Ok(post);
        }

        private async Task<IResult> GetPosts(IMediator mediator)
        {
            var getPosts = new GetAllPosts();
            var posts = await mediator.Send(getPosts);
            return TypedResults.Ok(posts);
        }

        private async Task<IResult> CreatePost(IMediator mediator, Post post)
        {
            var createPost = new CreatePost { PostContent = post.Content };
            var createdPost = await mediator.Send(createPost);
            return Results.CreatedAtRoute("GetPostById", new {createdPost.Id}, createdPost);
        }

        private async Task<IResult> UpdatePost(IMediator mediator, Post post, int id)
        {
            var updatePost = new UpdatePost { PostId = id, UpdateContent = post.Content };
            var updatedPost = await mediator.Send(updatePost);
            return TypedResults.Ok(updatedPost);
        }

        private async Task<IResult> DeletePost(IMediator mediator, int id)
        {
            var deletePost = new DeletePost { PostId = id };
            await mediator.Send(deletePost);
            return Results.NoContent();
        }
    }
}
