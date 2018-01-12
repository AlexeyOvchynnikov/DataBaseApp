using SQLite;

namespace DataBaseApp.Services.Interfaces
{
    public interface ISqLiteConnection
    {
        SQLiteConnection GetDatabaseConnection();
        SQLiteAsyncConnection GetDatabaseAsyncConnection();
    }
}