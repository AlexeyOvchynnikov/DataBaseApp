using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseApp.Services.Interfaces;
using MvvmCross.Platform.Platform;
using SQLite;

namespace DataBaseApp.Services
{
    public abstract class BaseMigration : IMigration
    {
        protected SQLiteAsyncConnection Connection;
        protected string MigrationName;

        public IMigration UseConnection(SQLiteAsyncConnection connection)
        {
            this.Connection = connection;
            MigrationName = this.GetType().Name;
            return this;
        }

        public virtual async Task<bool> Run()
        {
            try
            {
                MvxTrace.Trace("Executing {0}", MigrationName);
                var result = 0;
                var commands = GetCommands();
                foreach (var command in commands)
                {
                    MvxTrace.Trace("Executing command: '{0}'", command);
                    try
                    {
                        var commandResult = await Connection.ExecuteAsync(command);
                        MvxTrace.Trace("Executed command {0}. Rows affected {1}", command, commandResult);
                        result = result + commandResult;
                    }
                    catch (Exception ex)
                    {
                        MvxTrace.Error("Command execution error: {0}", ex.Message);
                        throw ex;
                    }
                }

                MvxTrace.Trace("{0} completed. Rows affected {1}", MigrationName, result);
                return result > 0;
            }
            catch (Exception ex)
            {
                MvxTrace.Error("{0} error: {1}", MigrationName, ex.Message);
                return false;
            }
        }

        protected abstract List<string> GetCommands();
    }
}
