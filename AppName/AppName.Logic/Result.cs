using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<ErrorMessage> Errors { get; set; }
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>()
            {
                IsSuccess = true,
                Value = value
            };
        }

        public static Result<T>Error<T>(string message)
        {
            return new Result<T>()
            {
                IsSuccess = false,
                Errors = new List<ErrorMessage>()
                {
                    new ErrorMessage()
                    {
                        PropertyName=string.Empty,
                        Message=message
                    }
                }
            };
        }

    }

    public class Result<T> : Result
    {
        public T Value { get; set; }
    }

    public class ErrorMessage
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
