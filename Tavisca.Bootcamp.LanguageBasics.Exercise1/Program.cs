using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static int FiDigit(string q, string w, string e, char nn) // f[0]..g[0]...g[1]
        {
            int res = 0;
            int y = 0;
            int a = Int32.Parse(w);
            int b = Int32.Parse(e);
            if (nn == '/')
            {
                if (b % a != 0)
                    return -1;
                res = b / a;
            }
            else
                res = b * a;
            y = q.IndexOf('?');
            string m = res.ToString();
            string k = "";
            for (int i = 0; i < q.Length; i++)
            {
                if (q[i] != '?')
                    k = k + q[i];
                else
                    k = k + m[y];
            }
            if (k.Equals(m))
                return m[y] - 48;
            else
                return -1;
        }
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string s)
        {
            var d = s.Length;
            string[] f = s.Split('*');
            string[] g = f[1].Split('=');
            Boolean flag;
            int result;
            if (f[0].Contains('?') || g[0].Contains('?'))
                flag = true;
            else
                flag = false;

            if (flag)
            {
                if (f[0].Contains('?')) // f[0]..g[0]...g[1]
                {
                    result = FiDigit(f[0], g[0], g[1], '/');
                }
                else
                {
                    result = FiDigit(g[0], f[0], g[1], '/');
                }
            }
            else
            {
                result = FiDigit(g[1], g[0], f[0], '*');
            }
            return result;
        }
    }
}
