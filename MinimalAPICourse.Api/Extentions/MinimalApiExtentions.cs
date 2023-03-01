using Microsoft.EntityFrameworkCore;
using MinimalAPICourse.Application.Abstractions;
using MinimalAPICourse.Application.Posts.Commands;
using MinimalAPICourse.Infrastructure.Repository;
using MinimalAPICourse.Infrastructure;
using MinimalAPICourse.Api.Abstractions;

namespace MinimalAPICourse.Api.Extentions
{
    public static class MinimalApiExtentions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SocialDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
            });
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreatePost).Assembly); });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinition>();

            foreach (var definition in endpointDefinitions)
            {
                definition.RegisterEndpoints(app);
            }
        }
    }
}
