using MemoryManagement;
using System.Runtime.InteropServices;

using static MemoryManagement.Kernel32;

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

unsafe
{
    void* ptr = HeapAlloc(HeapHandle, 0, 1024);

    if (ptr == null)
        throw new OutOfMemoryException();

    HeapFree(HeapHandle, 0, ptr);
}

Union u = new() { Value = 0xBEEF };

Console.WriteLine($"{u.HighByte:X2}"); // Prints "BE"
Console.WriteLine($"{u.LowByte:X2}");  // Prints "EF"

ReinterpretCast c = new() { Long = 47 };
Console.WriteLine(c.Double); // Prints "2.3E-322"

unsafe
{
    Console.WriteLine($"Size of {nameof(DefaultPackingSize)}: {sizeof(DefaultPackingSize)}");
    Console.WriteLine($"Size of {nameof(PackingSizeFour)}:    {sizeof(PackingSizeFour)}");
}