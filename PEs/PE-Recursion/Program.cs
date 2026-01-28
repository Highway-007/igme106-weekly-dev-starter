namespace PE_Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // local variables for testing our recursive methods
            const int NumElements = 5;
            int[] nums = new int[NumElements];
            int[] numsReverse = new int[NumElements];
            int[] numsRandom = new int[NumElements];
            Random rng = new Random();
            string word;

            // Setup 3 arrays - nums in order, nums in reverse order, nums with random values
            for (int i = 0; i < NumElements; i++)
            {
                nums[i] = i;
                numsReverse[i] = NumElements - i - 1;
                numsRandom[i] = rng.Next(0, NumElements * 3);
            }

            // Put the number 42 at a random location in the non-random arrays
            nums[rng.Next(NumElements)] = 42;
            numsReverse[rng.Next(NumElements)] = 42;

            // Print each array
            PrintArray("In order", nums);
            PrintArray("In reverse", numsReverse);
            PrintArray("Random", numsRandom);
            Console.WriteLine();

            // Calc the factorial of each random number
            for (int i = 0; i < NumElements; i++)
            {
                Console.WriteLine($"{numsRandom[i]}! = {Factorial(numsRandom[i])}");
            }
            Console.WriteLine();

            // Sum the elements of each array
            Console.WriteLine($"Sum of nums is {Sum(nums)}");
            Console.WriteLine($"Sum of numsReverse is {Sum(numsReverse)}");
            Console.WriteLine($"Sum of numsRandom is {Sum(numsRandom)}");
            Console.WriteLine();

            // Find if the number 3 is in each array
            Console.WriteLine($"Contains 3 in nums: {Contains(nums, 3)}");
            Console.WriteLine($"Contains 3 in numsReverse: {Contains(numsReverse, 3)}");
            Console.WriteLine($"Contains 3 in numsRandom: {Contains(numsRandom, 3)}");
            Console.WriteLine();

            // Find if the number 42 is in each array
            Console.WriteLine($"Contains 42 in nums: {Contains(nums, 42)}");
            Console.WriteLine($"Contains 42 in numsReverse: {Contains(numsReverse, 42)}");
            Console.WriteLine($"Contains 42 in numsRandom: {Contains(numsRandom, 42)}");
            Console.WriteLine();

            // Prompt the user for a word to test string methods
            Console.WriteLine("Enter a word:");
            word = Console.ReadLine();
            Console.WriteLine($"Is {word} a palindrome? {IsPalindrome(word)}");
            Console.WriteLine($"Reverse of {word} is {Reverse(word)}");
        }

        public static int PrintArray(string order, int[] nums)
        {
            //state change
            int[] recursiveNums = new int[nums.Length - 1];
            Array.Copy(nums, 0, recursiveNums, 0, recursiveNums.Length);

            //base case
            if (recursiveNums.Length <= 1)
            {
                Console.Write($"\n{order.Trim()}: {recursiveNums[0]} ");
                return recursiveNums[0];
            }
            //state change
            else
            {
                order = order + " ";
                PrintArray(order, recursiveNums);
                Console.Write($"{recursiveNums[recursiveNums.Length - 1]} ");

                if (order.Trim() + " " == order)
                {
                    Console.WriteLine(nums[nums.Length - 1]);
                }
                return nums[0];
            }
        }

        public static int Factorial(int num)
        {
            //base case
            if(num <= 1)
            {
                return 1;
            }

            //recursive case & state change;
            num *= Factorial(num - 1);
            return num;
        }

        public static int Sum(int[] nums)
        {
            //state change
            int[] recursiveNums = new int[nums.Length - 1];
            Array.Copy(nums, 0, recursiveNums, 0, recursiveNums.Length);

            //base case
            if (recursiveNums.Length <= 0)
            {
                return nums[0];
            }
            //state change
            else
            {
                recursiveNums[0] = Sum(recursiveNums);
                return recursiveNums[0] + nums[nums.Length - 1];
            }
        }

        public static bool Contains(int[] array, int num)
        {
            //state change
            int[] recursiveNums = new int[array.Length - 1];
            Array.Copy(array, 0, recursiveNums, 0, recursiveNums.Length);

            //base cases
            if (array[array.Length - 1] == num)
            {
                return true;
            }
            else if(recursiveNums.Length <= 0)
            {
                return false;
            }

            //state change
            else
            {
                if (Contains(recursiveNums, num))
                {
                    return true;
                }
                return false;
            }
        }

        public static bool IsPalindrome(string word)
        {
            return true;
        }

        public static string Reverse(string word)
        {
            return null;
        }
    }
}
