using System;
using System.Collections.Generic;

namespace ResultPattern
{
    public sealed class Result<TResult>
    {
        public TResult Value
        {
            init => _value = value;
            get => _errorMessage is null
                ? _value
                : throw new ValueNotFoundResultException();
        }

        public List<string> ErrorMessage
        {
            init => _errorMessage = value;
            get => _errorMessage is not null
                ? _errorMessage
                : throw new ErrorMessageNotFoundResultException();
        }

        private readonly List<string> _errorMessage = null;
        private readonly TResult _value;

        public bool Success { get => _errorMessage is null; }
        public bool Failure { get => _errorMessage is not null; }

        public Result(TResult value)
        {
            this.Value = value;
        }

        public Result(string errorMessage)
        {
            this.ErrorMessage = new List<string>() { errorMessage };
        }

        public Result(List<string> errorMessages)
        {
            this.ErrorMessage = errorMessages;
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

    public class ErrorMessageNotFoundResultException : ApplicationException
    {
        public ErrorMessageNotFoundResultException() { }
    }

    public class ValueNotFoundResultException : ApplicationException
    {
        public ValueNotFoundResultException() { }
    }
}
