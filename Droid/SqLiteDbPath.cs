using System.IO;
using DataBaseApp.Droid;
using DataBaseApp.Services.Interfaces;
using Xamarin.Forms;

namespace DataBaseApp.Droid
{
    public class SqLiteDbPath : ISqLiteDbPath
    {

        public string GetDatabasePath(string sqliteFilename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, sqliteFilename);
        }
    }
}