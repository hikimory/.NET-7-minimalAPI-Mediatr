using Microsoft.IdentityModel.Tokens;
using MinimalAPICourse.Domain.Models;

namespace MinimalAPICourse.Api.Filters
{
    public class PostValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<Post>(1);
            if (post.Content.IsNullOrEmpty()) return await Task.FromResult(Results.BadRequest("post's content is empty"));
            return await next(context);
        }
    }
}
