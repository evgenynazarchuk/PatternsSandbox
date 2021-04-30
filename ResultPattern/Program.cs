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
                Console.WriteLine($"{nameof(GetData1)}:" + result1.Value);
                Console.WriteLine($"{nameof(GetData1)}:" + string.Join("", result1.ErrorMessage)); // nothing\n
                Console.WriteLine($"{nameof(GetData1)}:" + result1.Exception); // nothing\n
            }
            else if(result1.Failure)
            {
                Console.WriteLine($"{nameof(GetData1)}:" + string.Join("", result1.ErrorMessage));
            }

            //
            Result<int> result2 = GetData2();
            if (result2.Success)
            {
                Console.WriteLine($"{nameof(GetData2)}:" + result2.Value);
            }
            else if (result2.Failure)
            {
                Console.WriteLine($"{nameof(GetData2)}:" + string.Join("", result2.ErrorMessage));
                Console.WriteLine($"{nameof(GetData2)}:" + result2.Value); // int -> 0
            }

            //
            Result<int> result3 = GetData3();
            if (result3.Success)
            {
                Console.WriteLine($"{nameof(GetData1)}:" + result3.Value);
            }
            else if (result3.Failure)
            {
                Console.WriteLine($"{nameof(GetData1)}:" + string.Join("\n", result3.ErrorMessage));
            }

            //
            Result<Point> result4 = GetData4();
            if (result4.Success)
            {
                Console.WriteLine($"{nameof(GetData1)}:" + $"{result4.Value.X} {result4.Value.Y}");
            }
            else if (result4.Failure)
            {
                Console.WriteLine($"{nameof(GetData1)}:" + string.Join("\n", result4.ErrorMessage));
            }

            //
            Result<Point> result5 = GetData5();
            if (result5.Success)
            {
                Console.WriteLine($"{nameof(GetData1)}:" + "{result5.Value.X} {result5.Value.Y}");
            }
            else if (result5.Failure)
            {
                Console.WriteLine($"{nameof(GetData1)}:" + string.Join("\n", result5.ErrorMessage));
            }
        }

        public static Result<int> GetData1()
        {
            return new Result<int>(42);
        }

        public static Result<int> GetData2()
        {
            return new Result<int>("Int Error");
        }

        public static Result<int> GetData3()
        {
            return new Result<int>(new List<string> { "Int Error 1", "Int Error 2" });
        }

        public static Result<Point> GetData4()
        {
            Point point = new Point { X = 1, Y = 2 };
            return new Result<Point>(point);
        }

        public static Result<Point> GetData5()
        {
            return new Result<Point>("Point Error");
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
