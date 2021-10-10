using CredoTasks.CRUD.Application.Contracts.Persistence;
using CredoTasks.CRUD.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CredoTasks.CRUD.Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CredoTasksDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CredoTasksConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
