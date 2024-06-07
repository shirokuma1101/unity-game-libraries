using System;

namespace UGL.ConvertDecimal
{
    public static class ConvertDecimal
    {
        const string CHARACTERS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const uint MAX_BASE = 62;

        /// <summary>
        /// Convert base(n) to decimal
        /// </summary>
        /// <param name="src"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static public ulong ConvertBaseNToDec(string src, uint n = MAX_BASE)
        {
            ulong converted = 0;

            if (n > MAX_BASE)
            {
                throw new Exception("Base value is too large.");
            }

            for (var i = 0; i < src.Length; i++)
            {
                var c = src[i];
                var charValue = (uint)CHARACTERS.IndexOf(c);
                converted = converted * n + charValue;
            }

            return converted;
        }

        /// <summary>
        /// Convert decimal to base(n)
        /// </summary>
        /// <param name="src"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static public string ConvertDecToBaseN(ulong src, uint n = MAX_BASE)
        {
            var converted = string.Empty;

            if (n > MAX_BASE)
            {
                throw new Exception("Base value is too large.");
            }

            while (src > 0)
            {
                var remainder = (int)(src % n);
                converted = CHARACTERS[remainder] + converted;
                src /= n;
            }

            return converted;
        }
    }
}
