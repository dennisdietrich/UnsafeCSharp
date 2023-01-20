namespace PointerDemo
{
    public class DemoClass
    {
        private int _integer;

        public unsafe void Pointers(double doubleParameter)
        {
            char character = 'C';
            byte[] managedByteArray = new byte[0];

            // Pin array and get pointer to first element
            fixed (byte* bytePtr = managedByteArray)
                ;
            // Pin object and get pointer to field
            fixed (int* intPtr = &_integer)
                ;

            // Get address of argument
            double* doublePtr = &doubleParameter;
            // Get address of local
            char* charPtr = &character;

            // Dereference pointer
            Console.WriteLine(*doublePtr);
            Console.WriteLine(*charPtr);

            Struct s = new Struct { Integer = 47, Double = 4.77 };
            Struct* sPtr = &s;

            // Dereference pointer and access member
            sPtr->Integer = 42;
            Console.WriteLine(sPtr->Integer);
            Console.WriteLine(sPtr->Double);

            // Allocate memory from call stack and return address
            byte* byteArray = stackalloc byte[1024];
            Guid* guidArray = stackalloc Guid[128];
        }

        public static unsafe void ManagedTypePointer()
        {
            var managed = new ManagedType();
            fixed (ushort* fieldPtr = &managed.Value)
            {
                ManagedType* objPtr = &managed;
                Console.WriteLine($"Ref address:    {(nuint)objPtr:X16}");
                Console.WriteLine($"Object address: {(nuint)(*(nuint**)objPtr):X16}");
                Console.WriteLine($"Field address:  {(nuint)fieldPtr:X16}");
                Console.WriteLine($"Field offset:   {(nuint)((byte*)fieldPtr - *(byte**)objPtr),16:X1}");
                Console.WriteLine($"Calculated:     {(ulong)(*(byte**)objPtr + sizeof(nint)):X16}");
                Console.WriteLine($"{*(ushort*)(*(byte**)objPtr + sizeof(nint)):X4}");
            }
        }
    }
}