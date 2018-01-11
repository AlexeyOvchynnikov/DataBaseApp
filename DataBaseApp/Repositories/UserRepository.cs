using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseApp.Models;
using DataBaseApp.Repositories.Interfaces;
using SQLite;

namespace DataBaseApp.Repositories
{
    public class UserRepository
    {
        private readonly SQLiteConnection _databaseConnection;

        public UserRepository(ISqLiteDbPath sqLiteDbPath)
        {
            var path = sqLiteDbPath.GetDatabasePath("database.db");
            _databaseConnection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.SharedCache);
            _databaseConnection.CreateTable<UserModel>();
        }
        public bool InsertOrUpdate(UserModel item)
        {
            try
            {
                _databaseConnection.InsertOrReplace(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(UserModel item)
        {
            try
            {
                _databaseConnection.Delete(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IList<UserModel> GetAll()
        {
            try
            {
                return _databaseConnection.Table<UserModel>().ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
