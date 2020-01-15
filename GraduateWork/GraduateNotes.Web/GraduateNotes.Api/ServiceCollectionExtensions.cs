using Microsoft.Extensions.DependencyInjection;

namespace GraduateNotes.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppInfrastructure(this IServiceCollection collection)
        {
            Service.Infrastructure.Component.Register(collection);
            return collection;
        }
    }
}
