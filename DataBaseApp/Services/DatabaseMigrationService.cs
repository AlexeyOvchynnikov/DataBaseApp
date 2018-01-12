
using DataBaseApp.Services.Interfaces;
using MvvmCross.Platform.Platform;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace DataBaseApp.Services
{
    public class DatabaseMigrationService : IMigrationService
    {
        private readonly SQLiteAsyncConnection _databaseAsyncConnection;
        private readonly ISettingsService _settings;
        private List<IMigration> _migrations;

        public DatabaseMigrationService(ISqLiteDbPath sqLiteDbPath, ISettingsService settings)
        {
            var path = sqLiteDbPath.GetDatabasePath("database.db");
            _databaseAsyncConnection = new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.SharedCache);
            this._settings = settings;

            SetupMigrations();
        }

        private void SetupMigrations()
        {
            _migrations = new List<IMigration>
            {
                new Migration(),
                new Migration1()
            };
        }

        public async Task<bool> RunMigrations()
        {
            // TODO run migrations in a transaction, otherwise, if and error is found, the app could stay in a horrible state

            if (_settings.DatabaseVersion >= _migrations.Count) return false;
            var count = 1;
            foreach (var migration in _migrations)
            {
                var success = await migration.UseConnection(_databaseAsyncConnection).Run();
                if (count == _migrations.Count && success)
                {
                    _settings.DatabaseVersion = count;
                    return true;
                }

                count++;

            }

            return false;
        }
    }
}
