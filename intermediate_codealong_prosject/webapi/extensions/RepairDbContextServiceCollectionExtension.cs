using core.Interfaces;
using Microsoft.EntityFrameworkCore;
using webapi.Context;

namespace webapi.extensions;

public static class RepairDbContextServiceCollectionExtension
{
    extension(IServiceCollection collection)
    {
        public IServiceCollection AddRepairDbContext(IConfiguration config)
        {
            collection.AddDbContext<IAsyncRepairRepository, RepairDbContext>(opt =>
                {
                    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                });
            return collection;
        }
    }
}