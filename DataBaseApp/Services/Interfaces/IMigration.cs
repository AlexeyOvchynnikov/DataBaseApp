using System.Threading.Tasks;
using SQLite;

namespace DataBaseApp.Services.Interfaces
{
    public interface IMigration
    {
        IMigration UseConnection(SQLiteAsyncConnection connection);
        Task<bool> Run();
    }
}