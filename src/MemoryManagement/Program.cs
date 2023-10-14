#define EXPLICIT_NO_PACK

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

#if UNION
Union u = new() { Value = 0xBEEF };

Console.WriteLine($"{u.HighByte:X2}"); // Prints "BE"
Console.WriteLine($"{u.LowByte:X2}");  // Prints "EF"

ReinterpretCast c = new() { Long = 47 };
Console.WriteLine(c.Double); // Prints "2.3E-322"
#endif

#if PACKING
unsafe
{
    Console.WriteLine($"Size of {nameof(DefaultPackingSize)}:  {sizeof(DefaultPackingSize)}");
    Console.WriteLine($"Size of {nameof(PackingSizeFour)}:     {sizeof(PackingSizeFour)}");
    Console.WriteLine($"Size of {nameof(ExplicitWithoutPack)}: {sizeof(ExplicitWithoutPack)}");
    Console.WriteLine($"Size of {nameof(ExplicitWithPack)}:    {sizeof(ExplicitWithPack)}");

    var defaultPack = new DefaultPackingSize();
    Console.WriteLine();
    Console.WriteLine($"Offset {nameof(DefaultPackingSize)}.{nameof(DefaultPackingSize.B1)}: {(int)(&defaultPack.B1 - &defaultPack.B1)}");
    Console.WriteLine($"Offset {nameof(DefaultPackingSize)}.{nameof(DefaultPackingSize.B2)}: {(int)(&defaultPack.B2 - &defaultPack.B1)}");
    Console.WriteLine($"Offset {nameof(DefaultPackingSize)}.{nameof(DefaultPackingSize.L)}:  {(int)((byte*)&defaultPack.L - &defaultPack.B1)}");

    var sizeFour = new PackingSizeFour();
    Console.WriteLine();
    Console.WriteLine($"Offset {nameof(PackingSizeFour)}.{nameof(PackingSizeFour.B1)}: {(int)(&sizeFour.B1 - &sizeFour.B1)}");
    Console.WriteLine($"Offset {nameof(PackingSizeFour)}.{nameof(PackingSizeFour.B2)}: {(int)(&sizeFour.B2 - &sizeFour.B1)}");
    Console.WriteLine($"Offset {nameof(PackingSizeFour)}.{nameof(PackingSizeFour.L)}:  {(int)((byte*)&sizeFour.L - &sizeFour.B1)}");

    var withoutPack = new ExplicitWithoutPack();
    Console.WriteLine();
    Console.WriteLine($"Offset {nameof(ExplicitWithoutPack)}.{nameof(ExplicitWithoutPack.B)}: {(int)(&withoutPack.B - &withoutPack.B)}");
    Console.WriteLine($"Offset {nameof(ExplicitWithoutPack)}.{nameof(ExplicitWithoutPack.I)}: {(int)((byte*)&withoutPack.I - &withoutPack.B)}");
    Console.WriteLine($"Offset {nameof(ExplicitWithoutPack)}.{nameof(ExplicitWithoutPack.L)}: {(int)((byte*)&withoutPack.L - &withoutPack.B)}");

    var withPack = new ExplicitWithPack();
    Console.WriteLine();
    Console.WriteLine($"Offset {nameof(ExplicitWithPack)}.{nameof(ExplicitWithPack.B)}: {(int)(&withPack.B - &withPack.B)}");
    Console.WriteLine($"Offset {nameof(ExplicitWithPack)}.{nameof(ExplicitWithPack.I)}: {(int)((byte*)&withPack.I - &withPack.B)}");
    Console.WriteLine($"Offset {nameof(ExplicitWithPack)}.{nameof(ExplicitWithPack.L)}: {(int)((byte*)&withPack.L - &withPack.B)}");

    var withoutPackArr = stackalloc ExplicitWithoutPack[2];
    var withPackArr = stackalloc ExplicitWithPack[2];
    Console.WriteLine();
    Console.WriteLine($"Offset second {nameof(ExplicitWithoutPack)} element: {(int)((byte*)&withoutPackArr[1] - (byte*)&withoutPackArr[0])}");
    Console.WriteLine($"Offset second {nameof(ExplicitWithPack)} element: {(int)((byte*)&withPackArr[1] - (byte*)&withPackArr[0])}");
}
#endif

#if EXPLICIT_NO_PACK || EXPLICIT_PACK
unsafe
{
#if EXPLICIT_NO_PACK
    var packStruct = new ExplicitWithoutPack();
    var size = sizeof(ExplicitWithoutPack);
#elif EXPLICIT_PACK
    var packStruct = new ExplicitWithPack();
    var size = sizeof(ExplicitWithPack);
#endif
    var baseAddr = &packStruct;
    Console.WriteLine($"Type:      {packStruct.GetType().Name}");
    Console.WriteLine($"Size:      {size}");
    Console.WriteLine($"Offsize B:  {(nuint)(&packStruct.B) - (nuint)baseAddr}");
    Console.WriteLine($"Offsize I:  {(nuint)(&packStruct.I) - (nuint)baseAddr}");
    Console.WriteLine($"Offsize L:  {(nuint)(&packStruct.L) - (nuint)baseAddr}");
}
#endif