namespace NetCore.Console
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            MultiThreading.Run();
            Console.ReadLine();
        }

        static void IsPrimeTest()
        {
            string input = "";
            while (input != "0")
            {
                input = Console.ReadLine();

                if (IsPrime(int.Parse(input)))
                {
                    Console.WriteLine(":> Prime!");
                }
                else
                {
                    Console.WriteLine(":> Not Prime!");
                }

            }
        }

        static bool IsPrime(int num)
        {


            if (num > 1 && num <= 3)
            {
                return true;
            }
            if (num % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
