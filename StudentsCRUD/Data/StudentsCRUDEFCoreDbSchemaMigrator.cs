using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace StudentsCRUD.Data;

public class StudentsCRUDEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public StudentsCRUDEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the StudentsCRUDDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<StudentsCRUDDbContext>()
            .Database
            .MigrateAsync();
    }
}
