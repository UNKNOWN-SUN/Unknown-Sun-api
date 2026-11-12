using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UNKOWNSUN.Data
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlite(
                "Data Source=../Registrar.sqlite",
                options => options.MigrationsAssembly("UNKNOWN-SUN-Api"));

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
