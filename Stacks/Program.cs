using System;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            // var stack = new ArrayStack(2);
            // Console.WriteLine(stack.ToString());
            // stack.Push(1);
            // stack.Push(2);
            // stack.Push(3);
            // Console.WriteLine(stack.ToString());

            // Given string of number 
            // string s = "123";

            // Function call 
            // convert(s);

            // var reversedString = ReverseAString("abc");
            // Console.WriteLine(reversedString);

            // Console.WriteLine(isPrime(11));

            Console.WriteLine(string.Join(",", GetFib(11)));
            //0, 1, 1, 2, 3, 5, 8, 13
            //input n output int[]
            //n = 3 => 0, 1, 1
        }

        // Function to convert string to 
        // integer without using functions 
        public static void convert(string s)
        {

            // Initialize a variable 
            int num = 0;

            // Iterate till length of the string 
            for (int i = 0; i < s.Length; i++)
            {
                // Subtract 48 from the current digit 
                num = num * 10 + ((int)s[i] - 48);
            }

            // Print the answer 
            Console.WriteLine(num);
        }

        public static int factorial(int n)
        {
            if (n <= 0)
            {
                return 1;
            }
            return n * factorial(n - 1);
        }

        public static string ReverseAString(string input)
        {
            if (input.Length == 1 || string.IsNullOrEmpty(input))
            {
                return input;
            }
            var firstChar = input[0];
            var y = input.AsSpan(1);
            var newStringInput = input.AsSpan(1).ToString();
            return ReverseAString(newStringInput) + firstChar;
        }

        public static bool isPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] GetFib(int n)
        {
            int[] output = new int[n];
            output[0] = 0;
            output[1] = 1;
            if (n < 2)
            {
                return output;
            }
            for (int i = 2; i < n; i++)
            {
                output[i] = output[i - 2] + output[i - 1];
            }
            return output;
        }
    }
}
