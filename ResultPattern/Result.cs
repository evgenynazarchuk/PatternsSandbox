using System;

namespace ResultPattern
{
    public class Result<TResult>
    {
        public TResult Value { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; } = default;

        public bool Success { get => _success; set => _success = value; }
        public bool Failure { get => !_success; set => _success = !value; }

        private bool _success;

        public Result(TResult value)
        {
            this.ErrorMessage = string.Empty;
            this.Exception = default;
            this.Value = value;
            this._success = true;
        }

        public Result(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Exception = new Exception(errorMessage);
            this._success = false;
        }

        public Result(Exception exception)
        {
            this.ErrorMessage = exception.Message;
            this.Exception = exception;
            this._success = false;
        }

        public Result(string errorMessage, Exception exception)
        {
            this.ErrorMessage = errorMessage;
            this.Exception = exception;
            this._success = false;
        }
    }
}
