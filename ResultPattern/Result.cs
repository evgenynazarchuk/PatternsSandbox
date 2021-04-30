using System;
using System.Collections.Generic;

namespace ResultPattern
{
    public sealed class Result<TResult>
    {
        public readonly TResult Value = default;
        public readonly List<string> ErrorMessage = new();
        
        public bool Success { get => ErrorMessage.Count == 0; }
        public bool Failure { get => ErrorMessage.Count != 0; }

        public Result(TResult value)
        {
            this.Value = value;
        }

        public Result(string errorMessage)
        {
            this.ErrorMessage.Add(errorMessage);
        }

        public Result(List<string> errorMessages)
        {
            this.ErrorMessage.AddRange(errorMessages);
        }

        public static Result<TResult> Create(TResult value) => new(value);
        public static Result<TResult> Create(string errorMessage) => new(errorMessage);
        public static Result<TResult> Create(List<string> errorMessages) => new(errorMessages);
    }

    public static class ResultExtension
    {
        public static string JoinErrorMessages<TResult>(this Result<TResult> result, string separator = " ")
        {
            return string.Join(separator, result.ErrorMessage);
        }
    }

    public class ResultException : Exception
    {
        public ResultException()
        {
        }
    }
}
