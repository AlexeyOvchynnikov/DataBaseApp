namespace DataBaseApp.Services.Interfaces
{
    public interface ISqLiteDbPath
    {
        string GetDatabasePath(string filename);
    }
}