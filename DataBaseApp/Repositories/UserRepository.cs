using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseApp.Models;
using DataBaseApp.Services.Interfaces;
using SQLite;

namespace DataBaseApp.Repositories
{
    public class UserRepository
    {
        private readonly SQLiteConnection _databaseConnection;
        private readonly SQLiteAsyncConnection _databaseAsyncConnection;

        public UserRepository(ISqLiteConnection sqLiteConnection)
        {
            _databaseAsyncConnection = sqLiteConnection.GetDatabaseAsyncConnection();
            _databaseConnection = sqLiteConnection.GetDatabaseConnection();

            var a = _databaseConnection.GetTableInfo("UserModel");
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
