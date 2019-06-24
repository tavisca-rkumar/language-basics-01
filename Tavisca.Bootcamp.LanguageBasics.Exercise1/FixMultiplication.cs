using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
      public static int getResult(string a, string b, string c, char calculation_sign) 
        {
            int result=0;
            int index = 0; //
            int denominator = Int32.Parse(b);
            int numerator = Int32.Parse(c);
            if (calculation_sign == '/')
            {
                if (numerator % denominator != 0)
                    return -1;
                result = numerator / denominator;
            }
            else
                result = numerator * denominator;
            index = a.IndexOf('?');
            string result_string = result.ToString();
            string rebuild_string = ""; 
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != '?')
                    rebuild_string = rebuild_string + a[i];
                else
                    rebuild_string = rebuild_string + result_string[index];
            }
            if (rebuild_string.Equals(result_string))
                return result_string[index] - 48;
            else
                return -1;
        }

        public static int FindDigit(string s)
        {
            int index1=s.LastIndexOf('?');
            int index2=s.IndexOf('?');
            if(index1!=index2)
            {
                return -1;
            }
            string[] f = s.Split('*');
            string[] g = f[1].Split('=');
            var a=f[0];
            var b=g[0];
            var c=g[1];
            Boolean isDivide;
            int result;
            if (a.Contains('?') || b.Contains('?'))
                isDivide = true;
            else
                isDivide = false;

            if (isDivide)
            {
                if (a.Contains('?'))
                {
                    result = getResult(a, b, c, '/');
                }
                else
                {
                    result = getResult(b, a, c, '/');
                }
            }
            else
            {
                result = getResult(c, b, a, '*');
            }
            return result;
        }
    }
}