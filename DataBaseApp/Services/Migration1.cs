using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApp.Services
{
    class Migration1 : BaseMigration
    {
        protected override List<string> GetCommands()
        {
            return new List<string>
            {
                "BEGIN TRANSACTION;",
                "ALTER TABLE UserModel RENAME TO tmp_UserModel;",

                //"CREATE TABLE \"UserModel\" (UserId VARCHAR(255), FirstName  VARCHAR(255), LastName VARCHAR(255),Patronymic VARCHAR(255),Integer INT,RegistrationDate DATETIME, Double DOUBLE);\n",

                "CREATE TABLE UserModel (" +
                "UserId VARCHAR(255) NOT NULL PRIMARY KEY," +
                "FirstName VARCHAR(255) NULL, " +
                "LastName VARCHAR(255)  NULL, " +
                "Patronymic VARCHAR(255)  NULL, " +
                "Integer NUMERIC  NULL," +
                "RegistrationDate DATETIME  NULL," +
                "Double DOUBLE  NULL" +
                ");",

                //"INSERT INTO UserModel VALUES ('1', 'Aceite', 'lastName', 'patronymic', '730','2017-01-12 10:45:30.120', '23.12');",

                "INSERT INTO \"UserModel\"(UserId, FirstName, LastName,Patronymic ,Integer,RegistrationDate, Double) SELECT NewUserId, FirstName, LastName,Patronymic ,Integer,RegistrationDate, Double FROM tmp_UserModel;\n",

                "DROP TABLE tmp_UserModel;",
                "COMMIT"
            };
        }
    }
}
