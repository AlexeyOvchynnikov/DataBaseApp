using System;
using System.IO;
using DataBaseApp.iOS;
using DataBaseApp.Repositories.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteDbPath))]
namespace DataBaseApp.iOS
{
    public class SqLiteDbPath : ISqLiteDbPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            var path = Path.Combine(libraryPath, sqliteFilename);

            return path;
        }
    }
}