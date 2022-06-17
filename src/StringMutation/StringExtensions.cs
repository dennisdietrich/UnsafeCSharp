namespace StringMutation
{
    public static class StringExtensions
    {
        // Method is declared unsafe
        public unsafe static void AsciiToUpper(this string s)
        {
            // Pins string and gets address of first element of char array
            fixed (char* p = s)
                for (int i = 0; i < s.Length; i++)
                    // Pointer element access
                    if (p[i] >= 'a' && p[i] <= 'z')
                        p[i] -= (char)('a' - 'A');
        }

        public unsafe static void BrokenAsciiToUpper(this string s)
        {
            fixed (char* p = s)
            {
                char* ptr = p;
                char* end = ptr + sizeof(char) * s.Length;

                while (true) // instead of (ptr < end)
                {
                    if (*ptr >= 'a' && *ptr <= 'z')
                        *ptr -= (char)('a' - 'A');

                    ptr++;
                }
            }
        }

        public unsafe static void AlsoBrokenAsciiToUpper(this string s)
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