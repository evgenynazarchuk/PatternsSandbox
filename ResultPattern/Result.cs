using System;
using System.Collections.Generic;

namespace ResultPattern
{
    public sealed class Result<TResult>
    {
        public readonly TResult Value = default;
        public readonly List<string> ErrorMessage = new();
        
        public bool Success { get => _success; }
        public bool Failure { get => !_success; }
        public readonly bool _success = false;

        public Result(TResult value)
        {
            this.Value = value;
            this._success = true;
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
