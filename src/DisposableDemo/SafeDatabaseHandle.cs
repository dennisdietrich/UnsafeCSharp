using System.Runtime.InteropServices;

namespace DisposableDemo
{
    internal sealed class SafeDatabaseHandle : SafeHandle
    {
        public override bool IsInvalid => handle == IntPtr.Zero;

        internal SafeDatabaseHandle() : base(IntPtr.Zero, true) { }

        protected override bool ReleaseHandle() => Sqlite.Close(handle) == 0;
    }
}