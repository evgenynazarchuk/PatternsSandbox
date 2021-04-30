using System;
using System.Collections.Generic;

namespace ResultPattern
{
    class Program
    {
        static void Main()
        {
            //
            Result<int> result1 = GetData1();
            if (result1.Success)
            {
                Console.WriteLine(result1.Value);
            }
            else if(result1.Failure)
            {
                Console.WriteLine(string.Join("", result1.ErrorMessage));
            }

            //
            Result<int> result2 = GetData2();
            if (result2.Success)
            {
                Console.WriteLine(result2.Value);
            }
            else if (result2.Failure)
            {
                Console.WriteLine(string.Join("", result2.ErrorMessage));
            }

            //
            Result<int> result3 = GetData3();
            if (result3.Success)
            {
                Console.WriteLine(result3.Value);
            }
            else if (result3.Failure)
            {
                Console.WriteLine(string.Join("\n", result3.ErrorMessage));
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

        public static Result<int> GetData3()
        {
            return new Result<int>(new List<string> { "Answer 1", "Answer 2" });
        }
    }
}
