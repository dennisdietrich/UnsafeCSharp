using System.Runtime.InteropServices;

namespace MemoryManagement
{
    // Assuming a little-endian system
    [StructLayout(LayoutKind.Explicit)]
    public struct Union
    {
        [FieldOffset(0)]
        public ushort Value;
        [FieldOffset(0)]
        public byte LowByte;
        [FieldOffset(1)]
        public byte HighByte;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct ReinterpretCast
    {
        [FieldOffset(0)]
        public long Long;
        [FieldOffset(0)]
        public double Double;
        [FieldOffset(0)]
        public void* Ptr;
    }
}