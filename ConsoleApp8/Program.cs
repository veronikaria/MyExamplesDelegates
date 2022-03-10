// See https://aka.ms/new-console-template for more information
using ConsoleApp8;


namespace ConsoleApp8 
{
    class Program
    {
        static void Main() 
        {
            // USE Action delegate
            Random random = new Random();
            Message message1 = new Message("mess1");
            Message message2 = new Message("mess2");
            Print(message1, message2, InfoMessage);

            int len = 4;
            int[] arr = new int[len];

            for (int i = 0; i < len; i++)
            {
                arr[i] = random.Next(0, 15);
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            // USE Predicate delegate

            CompareInformation(arr, len, IsOdd);


            // USE Func delegate

            ShowNumber(10.34, 4.5, 37.88, CreateStrNumberReverse);


        }

        static void ShowNumber(double f, double s, double t, Func<double, double, double, int> func) 
        {
            int resultNumber = func(f,s,t);

            Console.WriteLine($"We got the result number: {resultNumber}");
        }

        static int NumberBeforeSeparate(string number) 
        {
            string result = string.Empty;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '.' || number[i] == ',')
                    break;
                if (!Char.IsNumber(number[i]))
                    throw new NumberException();
                result += number[i];
            }

            bool res = int.TryParse(result, out int num);
            if (!res)
                throw new NumberException();

            return num;
        }
        static int CreateStrNumberReverse(double first, double second, double third) 
        {
            string firstStr = first.ToString();
            string secondStr = second.ToString();
            string thirdStr = third.ToString();

            try
            {
                int f = NumberBeforeSeparate(firstStr);
                int s = NumberBeforeSeparate(secondStr);
                int t = NumberBeforeSeparate(thirdStr);

                string result = $"{t}{s}{f}";

                bool res = int.TryParse(result, out int n);

                if (!res)
                    throw new NumberException();
                return n;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return -1;
        }

        static void InfoMessage(string s1, string s2) 
        {
            Console.WriteLine($"Messages: {s1}; {s2}");
        }

        static void Print(Message m1, Message m2, Action<string, string> show) 
        {
            show(m1.Text, m2.Text);
        }

        static bool IsOdd(int number) => number % 2 != 0;
        static bool IsEven(int number) => number % 2 == 0;

        static void CompareInformation(int[] nums, int len, Predicate<int> comp) 
        {
            bool end = true;
            for (int i = 0; i < len; i++)
            {
                if (!comp(nums[i]))
                {
                    end = false;
                    break;
                }
            }

            if (end) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}









