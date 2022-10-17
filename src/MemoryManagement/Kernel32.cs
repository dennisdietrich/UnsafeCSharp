using System.Runtime.InteropServices;

namespace MemoryManagement
{
    internal static class Kernel32
    {
        private const string DllName = "kernel32.dll";

        internal static readonly IntPtr HeapHandle = GetProcessHeap();

        [DllImport(DllName)]
        internal static extern IntPtr GetProcessHeap();

        [DllImport(DllName)]
        internal static extern unsafe void* HeapAlloc(IntPtr hHeap, uint dwFlags, nuint dwBytes);

        [DllImport(DllName)]
        internal static extern unsafe int HeapFree(IntPtr hHeap, uint dwFlags, void* lpMem);
    }
}