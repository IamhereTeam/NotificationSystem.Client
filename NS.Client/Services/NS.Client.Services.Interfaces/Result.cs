using System;
using System.Net;

namespace NS.Client.Services.Interfaces
{
    public class Result
    {
        public bool Succeeded { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }
        public string Message { get; protected set; }
        public Exception Exception { get; protected set; }

        public Result Succeed(HttpStatusCode statusCode = default)
        {
            Succeeded = true;
            StatusCode = statusCode;
            return this;
        }

        public Result Failed(HttpStatusCode statusCode = default, string message = default, Exception exception = default)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = message;
            Exception = exception;
            return this;
        }
    }

    public class Result<T>
    {
        public bool Succeeded { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }
        public string Message { get; protected set; }
        public Exception Exception { get; protected set; }
        public T Data { get; set; }

        public Result<T> Succeed(T data, HttpStatusCode statusCode = default)
        {
            Succeeded = true;
            Data = data;
            StatusCode = statusCode;
            return this;
        }

        public Result<T> Failed(HttpStatusCode statusCode = default, string message = default, Exception exception = default)
        {
            Succeeded = false;
            Data = default;
            StatusCode = statusCode;
            Message = message;
            Exception = exception;
            return this;
        }
    }
}