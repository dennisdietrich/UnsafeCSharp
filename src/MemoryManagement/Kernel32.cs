using System.Runtime.InteropServices;

namespace MemoryManagement
{
    internal static class Kernel32
    {
        internal const string DllName = "Kernel32";

        internal static readonly IntPtr HeapHandle = GetProcessHeap();

        [DllImport(DllName)]
        internal static extern IntPtr GetProcessHeap();

        [DllImport(DllName)]
        internal static unsafe extern void* HeapAlloc(IntPtr hHeap, uint dwFlags, nuint dwBytes);

        [DllImport(DllName)]
        internal static unsafe extern int HeapFree(IntPtr hHeap, uint dwFlags, void* lpMem);
    }
}