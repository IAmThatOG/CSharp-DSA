using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array Demo
            var newArray = new MyArray();
            newArray.Push("Hello");
            newArray.Push("Hi");
            newArray.Push("Me");
            Console.WriteLine(newArray.ToString());
            newArray.Pop();
            Console.WriteLine(newArray.ToString());
            newArray.Delete(0);
            Console.WriteLine(newArray.ToString());

            var resultOne = ReverseOne("Hi my name is Gabriel");
            Console.WriteLine($"Reverse String Method One: {resultOne}");

            var resultTwo = ReverseTwo("Hi my name is Gabriel");
            Console.WriteLine($"Reverse String Method Two: {string.Join(',', resultTwo)}");

            var mergeSortedArray = MergeSortedArraysOne(new int[] { 0, 3 }, new int[] { 2, 4, 9 });
            Console.WriteLine($"Merge sorted arrays Method One: {string.Join(',', mergeSortedArray)}");

            var isAnagram = IsAnagram("Dormitory", "Dirty room");
            Console.WriteLine($"Is anagram Method One: {isAnagram}");

            var isAnagram2 = IsAnagram("Time and tide wait for no man", "Notified madman into water");
            Console.WriteLine($"Is anagram Method Two: {isAnagram2}");

            var reversedWord = WordFlipper("This is an example");
            Console.WriteLine($"Is anagram Method One: {reversedWord}");

            var hammingDistance = HammingDistance("ACTTGACCGGG", "GATCCGGTACA");
            Console.WriteLine($"Hamming distance: {hammingDistance}");
        }

        public static string ReverseOne(string input)
        {
            if (input is null)
            {
                return string.Empty;
            }

            if (input.Length == 1)
            {
                return input;
            }

            var newString = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                newString += input[i];
            }
            return newString;
        }

        public static string ReverseTwo(string input)
        {
            if (input is null)
            {
                return string.Empty;
            }

            if (input.Length == 1)
            {
                return input;
            }
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return charArray.ToString();
        }

        public static int[] MergeSortedArraysOne(int[] arrayOne, int[] arrayTwo)
        {
            if (arrayOne.Length == 0)
            {
                return arrayTwo;
            }

            if (arrayTwo.Length == 0)
            {
                return arrayOne;
            }

            var mergedArray = new int[arrayOne.Length + arrayTwo.Length];
            var arrayOneIndex = 0;
            var arrayTwoIndex = 0;
            var mergedArrayIndex = 0;
            while (arrayOneIndex < arrayOne.Length || arrayTwoIndex < arrayTwo.Length)
            {
                if (arrayTwoIndex == arrayTwo.Length)
                {
                    mergedArray[mergedArrayIndex] = arrayOne[arrayOneIndex];
                    mergedArrayIndex++;
                    arrayOneIndex++;
                }
                else if (arrayOneIndex == arrayOne.Length)
                {
                    mergedArray[mergedArrayIndex] = arrayTwo[arrayTwoIndex];
                    mergedArrayIndex++;
                    arrayTwoIndex++;
                }
                else if (arrayOne[arrayOneIndex] <= arrayTwo[arrayTwoIndex])
                {
                    mergedArray[mergedArrayIndex] = arrayOne[arrayOneIndex];
                    mergedArrayIndex++;
                    arrayOneIndex++;
                }
                else
                {
                    mergedArray[mergedArrayIndex] = arrayTwo[arrayTwoIndex];
                    mergedArrayIndex++;
                    arrayTwoIndex++;
                }
            }
            return mergedArray;
        }

        public static bool IsAnagram(string str1, string str2)
        {
            var str1Array = str1.Trim().Replace(" ", string.Empty).ToLower().ToCharArray();
            var str2Array = str2.Trim().Replace(" ", string.Empty).ToLower().ToCharArray();
            if (str1Array.Length != str2Array.Length)
            {
                return false;
            }
            Array.Sort(str1Array);
            Array.Sort(str2Array);
            if (Array.Equals(str1Array, str2Array))
            {
                return false;
            }
            return true;
        }

        public static string WordFlipper(string str1)
        {
            var str1Array = str1.Trim().Split(" ");
            var result = string.Empty;
            for (var i = 0; i < str1Array.Length; i++)
            {
                var word = str1Array[i].ToCharArray();
                Array.Reverse(word);
                result += new String(word) + " ";
            }
            return result.Trim();
        }

        public static int HammingDistance(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                var distance = 0;
                for (var i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        distance += 1;
                    }
                }
                return distance;
            }
            return 0;
        }
    }
}
