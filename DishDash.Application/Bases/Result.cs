﻿using System.Net;

namespace DishDash.Application.Bases
{
    public class Result<T>
    {
        public Result()
        {

        }
        public Result(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Result(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Result(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public object? Meta { get; set; }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }

        public T? Data { get; set; }
    }
}
