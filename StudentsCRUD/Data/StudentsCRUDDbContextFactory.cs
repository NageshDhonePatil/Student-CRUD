using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentsCRUD.Data;

public class StudentsCRUDDbContextFactory : IDesignTimeDbContextFactory<StudentsCRUDDbContext>
{
    public StudentsCRUDDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<StudentsCRUDDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new StudentsCRUDDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
