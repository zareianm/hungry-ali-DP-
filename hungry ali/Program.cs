using System;

namespace hungry_ali
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split(' ');

            long n = long.Parse(s[0]);
            long p = long.Parse(s[1]);

            s= Console.ReadLine().Split(' ');

            long[] path1 = new long[n];

            for (long i = 0; i < n; i++)
            {
                path1[i] = long.Parse(s[i]);
            }

            s = Console.ReadLine().Split(' ');

            long[] path2 = new long[n];

            for (long i = 0; i < n; i++)
            {
                path2[i] = long.Parse(s[i]);
            }

            Console.WriteLine(MostFood(path1,path2,n,p));
        }

        private static long MostFood(long[] path1, long[] path2, long n, long p)
        {
            long[] f1 = new long[n];
            long[] f2 = new long[n];

            f1[0] = path1[0];
            f2[0] = path2[0];

            for (long i = 1; i < n; i++)
            {
                if (f1[i - 1] + path1[i] >= f2[i - 1] + path1[i] - p)
                    f1[i] = f1[i - 1] + path1[i];

                else
                    f1[i] = f2[i - 1] + path1[i] - p;

                if (f2[i - 1] + path2[i] >= f1[i - 1] + path2[i] - p)
                    f2[i] = f2[i - 1] + path2[i];

                else
                    f2[i] = f1[i - 1] + path2[i] - p;
            }

            return Math.Max(f1[n - 1], f2[n - 1]);
        }
    }
}
