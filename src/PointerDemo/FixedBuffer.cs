namespace PointerDemo
{
    // Fixed size buffer type must be one of the following:
    // bool, byte, short, int, long, char, sbyte, ushort, uint, ulong, float, double
    public unsafe struct FixedBuffer
    {
        public int Integer;
        public fixed byte ByteBuffer[128]; // Type of ByteBuffer is byte*
    }
}