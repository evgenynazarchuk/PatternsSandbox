using System;
using System.Collections.Generic;

namespace ResultPattern
{
    public sealed class Result<TResult>
    {
        public readonly TResult Value = default;
        public readonly Exception Exception = default;
        public readonly List<string> ErrorMessage = new();

        public bool Success { get => _success; set { } }
        public bool Failure { get => !_success; set { } }
        private readonly bool _success = false;

        public Result(TResult value)
        {
            this.Value = value;
            this._success = true;
        }

        public Result(string errorMessage)
        {
            this.ErrorMessage.Add(errorMessage);
        }

        public Result(Exception exception)
        {
            this.ErrorMessage.Add(exception.Message);
            this.Exception = exception;
        }

        public Result(string errorMessage, Exception exception)
        {
            this.ErrorMessage.Add(errorMessage);
            this.Exception = exception;
        }

        public Result(List<string> errorMessages)
        {
            this.ErrorMessage.AddRange(errorMessages);
        }
    }

    public static class ResultExtension
    {
        public static string JoinErrorMessages<TResult>(this Result<TResult> result, string separator = " ")
        {
            return string.Join(separator, result.ErrorMessage);
        }
    }
}
