
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
                new Migration()
            };
        }

        public async Task<bool> RunMigrations()
        {
            // TODO run migrations in a transaction, otherwise, if and error is found, the app could stay in a horrible state
            var result = false;
            if (_settings.DatabaseVersion < _migrations.Count)
            {

                while (_settings.DatabaseVersion < _migrations.Count)
                {
                    var nextVersion = _settings.DatabaseVersion + 1;
                    var success = await _migrations[nextVersion - 1].UseConnection(_databaseAsyncConnection).Run();

                    if (success)
                    {
                        _settings.DatabaseVersion = nextVersion;
                        result = true;
                    }
                    else
                    {
                        MvxTrace.Error("Migration process stopped after error found at {0}", _migrations[nextVersion - 1].GetType().Name);
                        break;
                    }
                }

            }

            return result;
        }
    }
}
