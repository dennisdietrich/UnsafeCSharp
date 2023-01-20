using System.Runtime.InteropServices;

namespace MemoryManagement
{
    // sizeof(DefaultPackingSize) = 16
    public struct DefaultPackingSize
    {
        public byte B1; // offset: 0
        public byte B2; // offset: 1
        public long L;  // offset: 8
    }

    // sizeof(PackingSizeFour) = 12
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct PackingSizeFour
    {
        public byte B1; // offset: 0
        public byte B2; // offset: 1
        public long L;  // offset: 4
    }

    // sizeof(ExplicitWithoutPack) = 16
    [StructLayout(LayoutKind.Explicit)]
    public struct ExplicitWithoutPack
    {
        [FieldOffset(0)]
        public byte B;
        [FieldOffset(1)]
        public int I;
        [FieldOffset(5)]
        public long L;
    }

    // sizeof(ExplicitWithPack) = 13
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct ExplicitWithPack
    {
        [FieldOffset(0)]
        public byte B;
        [FieldOffset(1)]
        public int I;
        [FieldOffset(5)]
        public long L;
    }
}