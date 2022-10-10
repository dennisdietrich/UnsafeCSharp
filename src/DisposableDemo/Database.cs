namespace DisposableDemo
{
    public sealed class Database : IDisposable
    {
        private readonly SafeDatabaseHandle _databaseHandle;

        public Database(string filename)
        {
            if (Sqlite.Open(filename, out _databaseHandle) != 0)
                throw new Exception("Failed to open database.");
        }

        // Look mom! No finalizer!

        public unsafe void Execute(string sql, Callback? callback = null)
        {
            // Look mom! No 'disposed' check!
            if (Sqlite.Execute(_databaseHandle, sql, callback, null, null) != 0)
                throw new Exception("Script execution failed.");
        }

        public unsafe void Execute(string sql, delegate* unmanaged<void*, int, byte**, byte**, int> callback)
        {
            // Look mom! No 'disposed' check!
            if (Sqlite.Execute(_databaseHandle, sql, callback, null, null) != 0)
                throw new Exception("Script execution failed.");
        }

        // No need for overloads since the class is sealed.
        public void Dispose()
        {
            if (_databaseHandle.IsInvalid == false)
                _databaseHandle.Dispose();
        }
    }
}