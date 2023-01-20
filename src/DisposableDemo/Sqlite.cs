using System.Runtime.InteropServices;

namespace DisposableDemo
{
    public unsafe delegate ResultCode Callback(void* ptr, int columns, byte** values, byte** names);

    internal static class Sqlite
    {
        private const string DllName = "sqlite3.dll";

        [DllImport(DllName, EntryPoint = "sqlite3_open")]
        internal static extern int Open([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, out SafeDatabaseHandle pDb);

        [DllImport(DllName, EntryPoint = "sqlite3_close_v2")]
        internal static extern int Close(IntPtr pDb);

        [DllImport(DllName, EntryPoint = "sqlite3_exec")]
        internal static extern unsafe int Execute(SafeDatabaseHandle pDb, [MarshalAs(UnmanagedType.LPUTF8Str)] string sql, Callback? callback, void* firstArg, byte** errMsg);

        [DllImport(DllName, EntryPoint = "sqlite3_exec")]
        internal static extern unsafe int Execute(SafeDatabaseHandle pDb, [MarshalAs(UnmanagedType.LPUTF8Str)] string sql, delegate* unmanaged[Cdecl]<void*, int, byte**, byte**, ResultCode> callback, void* firstArg, byte** errMsg);
    }
}