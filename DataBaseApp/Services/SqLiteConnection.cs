using DataBaseApp.Services.Interfaces;
using SQLite;

namespace DataBaseApp.Services
{
    public class SqLiteConnection : ISqLiteConnection
    {
        private readonly SQLiteConnection _databaseConnection;
        private readonly SQLiteAsyncConnection _databaseAsyncConnection;

        public SqLiteConnection(ISqLiteDbPath sqLiteDbPath)
        {
            var path = sqLiteDbPath.GetDatabasePath("database.db");
            _databaseConnection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.SharedCache); ;
            _databaseAsyncConnection = new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.SharedCache); ;
        }
        public SQLiteConnection GetDatabaseConnection()
        {
            return _databaseConnection;
        }

        public SQLiteAsyncConnection GetDatabaseAsyncConnection()
        {
            return _databaseAsyncConnection;
        }
    }
}
