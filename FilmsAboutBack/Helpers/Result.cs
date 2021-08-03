﻿using System.Net;

namespace FilmsAboutBack.Helpers
{
    public class Result<T>
    {
        public Result(T value)
        {
            Value = value;
        }

        private Result(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public T Value { get; set; }
        public string Message { get; private set; } = "";
        public HttpStatusCode StatusCode = HttpStatusCode.OK;
        public bool IsSucceeded => StatusCode == HttpStatusCode.OK;

        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Success(T value, string message)
        {
            return new Result<T>(value)
            {
                Message = message
            };
        }

        public static Result<T> BadRequest(string message)
        {
            return new Result<T>(HttpStatusCode.BadRequest)
            {
                Message = message
            };
        }

        public static Result<T> NotFound(string message)
        {
            return new Result<T>(HttpStatusCode.NotFound)
            {
                Message = message
            };
        }

        public static Result<T> ServerError(string message)
        {
            return new Result<T>(HttpStatusCode.InternalServerError)
            {
                Message = message
            };
        }
    }
}