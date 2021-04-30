using System;

namespace ResultPattern
{
    class Program
    {
        static void Main()
        {
            //
            Result<int> result1 = GetData1();
            Result<int> result2 = GetData2();

            //
            if (result1.Success)
            {
                Console.WriteLine(result1.Value);
            }
            else if(result1.Failure)
            {
                Console.WriteLine(result1.ErrorMessage);
            }

            //
            if (result2.Success)
            {
                Console.WriteLine(result2.Value);
            }
            else if (result2.Failure)
            {
                Console.WriteLine(result2.ErrorMessage);
            }
        }

        public static Result<int> GetData1()
        {
            return new Result<int>(42);
        }

        public static Result<int> GetData2()
        {
            return new Result<int>("Answer");
        }
    }
}
