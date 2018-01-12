using System.Threading.Tasks;

namespace DataBaseApp.Services.Interfaces
{
    internal interface IMigrationService
    {
        Task<bool> RunMigrations();
    }
}
