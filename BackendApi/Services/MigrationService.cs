using BackendApi.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Services
{
    public class MigrationService
    {
        private readonly ApplicationContext _context;

        public MigrationService(ApplicationContext context)
        {
            _context = context;
        }

        public void ApplyMigrations()
        {
            _context.Database.Migrate();
        }
    }
}
