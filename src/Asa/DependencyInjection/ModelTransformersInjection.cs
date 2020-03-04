using Asa.Models;
using Asa.Models.Activity;
using Microsoft.Extensions.DependencyInjection;

namespace Asa.DependencyInjection
{
    public static class ModelTransformersInjection
    {
        public static IServiceCollection AddModelTransformers(this IServiceCollection services)
        {
            services.AddScoped<User.Transformer>();
            services.AddScoped<Directory.Transformer>();
            services.AddScoped<Document.Transformer>();
            services.AddScoped<Line.Transformer>();

            services.AddScoped<Insertion.Transformer>();
            services.AddScoped<Modification.Transformer>();
            services.AddScoped<Deletion.Transformer>();

            return services;
        }
    }
}
