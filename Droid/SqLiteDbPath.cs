using System.IO;
using DataBaseApp.Droid;
using DataBaseApp.Repositories.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteDbPath))]
namespace DataBaseApp.Droid
{
    public class SqLiteDbPath : ISqLiteDbPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, sqliteFilename);
        }
    }
}