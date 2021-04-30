using System;
using System.Collections.Generic;

namespace ResultPattern
{
    class Program
    {
        static void Main()
        {
            //
            string category1 = nameof(GetData1);
            string category2 = nameof(GetData2);
            string category3 = nameof(GetData3);
            string category4 = nameof(GetData4);
            string category5 = nameof(GetData5);

            //
            Result<int> result1 = GetData1();
            if (result1.Success)
            {
                Console.WriteLine($"{category1}:" + result1.Value);
                Console.WriteLine($"{category1}:" + result1.JoinErrorMessages()); // nothing\n
            }
            else if(result1.Failure)
            {
                Console.WriteLine($"{category1}:" + result1.JoinErrorMessages());
            }

            //
            Result<int> result2 = GetData2();
            if (result2.Success)
            {
                Console.WriteLine($"{category2}:" + result2.Value);
            }
            else if (result2.Failure)
            {
                Console.WriteLine($"{category2}:" + result2.JoinErrorMessages());
                Console.WriteLine($"{category2}:" + result2.Value); // int -> 0
            }

            //
            Result<int> result3 = GetData3();
            if (result3.Success)
            {
                Console.WriteLine($"{category3}:" + result3.Value);
            }
            else if (result3.Failure)
            {
                Console.WriteLine($"{category3}:" + result3.JoinErrorMessages());
            }

            //
            Result<Point> result4 = GetData4();
            if (result4.Success)
            {
                Console.WriteLine($"{category4}:" + $"{result4.Value.X} {result4.Value.Y}");
            }
            else if (result4.Failure)
            {
                Console.WriteLine($"{category4}:" + result4.JoinErrorMessages());
            }

            //
            Result<Point> result5 = GetData5();
            if (result5.Success)
            {
                Console.WriteLine($"{category5}:" + $"{result5.Value.X} {result5.Value.Y}");
            }
            else if (result5.Failure)
            {
                Console.WriteLine($"{category5}:" + result5.JoinErrorMessages());
            }
        }

        public static Result<int> GetData1()
        {
            return Result<int>.Create(42);
        }

        public static Result<int> GetData2()
        {
            return Result<int>.Create("Int Error");
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
