using System;
using System.Linq;
using System.Collections.Generic;


namespace CrossoverNetchallange
{
    class MainClass
    {
        public static int CountOnes(int n)
        {
            int count = 0;
            while (n!=0)
            {
                count += n & 1;
                n = n >> 1;
            }

            return count;
        }

        public static int[] rearrange(int[] elements)
        {
            Array.Sort(elements,new Comparison<int>((i1,i2)=>{
                int onesI1 = CountOnes(i1);
                int onesI2 = CountOnes(i2);
                if (onesI1 < onesI2)
                    return -1;
                if(onesI1 == onesI2)
                {
                    return i1.CompareTo(i2);
                }

                return 0;
            }));

            return elements;
        }

       

        static int[] balancedOrNot(string[] expressions, int[] maxReplacements)
        {
            var results = new int[maxReplacements.Length];
            int index = 0;
            foreach (var expression in expressions)
            {
                Stack<char> lessThan = new Stack<char>();
                Stack<char> greaterThan = new Stack<char>();
                foreach (char c in expression)
                {
                    if (c == '<')
                        lessThan.Push(c);
                    if (c == '>')
                        greaterThan.Push(c);

                }

                if (lessThan.Count == greaterThan.Count && maxReplacements[index] !=0)
                    results[index] = 1;
                else 
                {
                    if (Math.Abs(lessThan.Count - greaterThan.Count)<=maxReplacements[index] && maxReplacements[index] !=0)
                        results[index] = 1;
                    else
                        results[index] = 0;
                }

                index++;
                    
            }

            return results;
        }

        public static void Main(string[] args)
        {

            var exp = new string[] { "<>>>", "<>>>>" };
            int[] replacements = new int[] { 2, 2 };
            var arr = balancedOrNot(exp, replacements);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.Read();

        }
    }
}
