using System.Runtime.InteropServices;

namespace DisposableDemo
{
    internal static class Sqlite
    {
        internal unsafe delegate int Callback(void* ptr, int columns, out byte* values, out byte* names);

        internal const string DllName = "sqlite3";

        [DllImport(DllName, EntryPoint = "sqlite3_open")]
        internal static extern int Open([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, out SafeDatabaseHandle pDb);

        [DllImport(DllName, EntryPoint = "sqlite3_close_v2")]
        internal static extern int Close(IntPtr pDb);

        [DllImport(DllName, EntryPoint = "sqlite3_exec")]
        internal static unsafe extern int Execute(SafeDatabaseHandle pDb, [MarshalAs(UnmanagedType.LPUTF8Str)] string sql, Callback? callback, void* firstArg, byte** errMsg);
    }
}