using System;

namespace ResultPattern
{
    public class Result<TResult>
    {
        public readonly TResult Value = default;
        public readonly Exception Exception = default;
        public readonly string ErrorMessage = string.Empty;

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
            this.ErrorMessage = errorMessage;
            this.Exception = new Exception(errorMessage);
        }

        public Result(Exception exception)
        {
            this.ErrorMessage = exception.Message;
            this.Exception = exception;
        }

        public Result(string errorMessage, Exception exception)
        {
            this.ErrorMessage = errorMessage;
            this.Exception = exception;
        }
    }
}
