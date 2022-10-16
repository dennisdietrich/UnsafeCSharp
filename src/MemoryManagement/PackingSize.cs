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
}