using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace POS.API.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connStr = Environment.GetEnvironmentVariable("MYSQL_CONNECTION") ??
            "Server=localhost;Database=posdb;Uid=root;Pwd=pass;";
        optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
