namespace StringMutation
{
    public static class StringExtensions
    {
        public unsafe static void AsciiToUpper(this string s)
        {
            fixed (char* p = s)
                for (int i = 0; i < s.Length; i++)
                    if (p[i] >= 'a' || p[i] <= 'z')
                        p[i] -= (char)('a' - 'A');
        }
    }
}