namespace StringMutation
{
    public static class StringExtensions
    {
        // Method is declared unsafe
        public static unsafe void AsciiToUpper(this string s)
        {
            // Pins string and gets address of first element of char array
            fixed (char* p = s)
                for (int i = 0; i < s.Length; i++)
                    // Pointer element access
                    if (p[i] >= 'a' && p[i] <= 'z')
                        p[i] -= (char)('a' - 'A');
        }

        public static unsafe void AsciiToUpperAlt(this string s)
        {
            fixed (char* p = s)
            {
                char* ptr = p;
                // Pointer arithmetic
                char* end = ptr + s.Length;

                // Pointer comparison
                while (ptr < end)
                {
                    if (*ptr >= 'a' && *ptr <= 'z')
                        *ptr -= (char)('a' - 'A');

                    // Pointer increment
                    ptr++;
                }
            }
        }

        public static unsafe void BrokenAsciiToUpper(this string s)
        {
            char* ptr;

            fixed (char* p = s)
                ptr = p;

            // string s is not pinned anymore, ptr may or may not point to it
            for (int i = 0; i < s.Length; i++)
                if (ptr[i] >= 'a' && ptr[i] <= 'z')
                    ptr[i] -= (char)('a' - 'A');
        }
    }
}