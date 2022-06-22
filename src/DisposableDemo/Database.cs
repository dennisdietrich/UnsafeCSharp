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

        public unsafe void Execute(string sql)
        {
            if (Sqlite.Execute(_databaseHandle, sql, null, null, null) != 0)
                throw new Exception("Script execution failed.");
        }

        public void Dispose()
        {
            if (_databaseHandle?.IsInvalid == false)
                _databaseHandle.Dispose();
        }
    }
}