namespace DataBaseApp.Repositories.Interfaces
{
    /// <summary>
    /// An interface containing a method for obtaining the path to the local database
    /// </summary>
    public interface ISqLiteDbPath
    {
        /// <summary>
        /// Gets the database path.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        string GetDatabasePath(string filename);
    }
}
