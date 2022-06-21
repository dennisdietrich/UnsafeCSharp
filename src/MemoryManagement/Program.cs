using System.Runtime.InteropServices;

// The following code is not unsafe:
// Allocate memory from default heap
IntPtr intPtr = Marshal.AllocHGlobal(1024);
// Free memory
Marshal.FreeHGlobal(intPtr);

unsafe
{
    // Allocate heap memory using C standard library function malloc()
    void* ptr = NativeMemory.Alloc(1024);
    // Free heap memory using C standard library function free()
    NativeMemory.Free(ptr);
}