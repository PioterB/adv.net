using System;
using System.Net;

namespace LevelUpCSharp
{
    public class Result<T>
    {
        private readonly T _inner;
        private readonly bool _failed;

        private Result(T inner)
        {
            _inner = inner;
            _failed = object.Equals(inner, default(T));
        }

        public static Result<T> Success(T result)
        {
            if (object.Equals(default(T), result))
            {
                throw new InvalidOperationException("Successful operation expects existing argument");
            }

            return new Result<T>(result);
        }

        public static Result<T> Failed()
        {
            return new Result<T>(default(T));
        }

        public bool Fail => _failed;

        public T Value
        {
            get
            {
                if (_failed)
                {
                    throw new InvalidOperationException($"Negative result, no value. Use instance's '{nameof(Fail)}' to check if value is present");
                }

                return _inner;
            }
        }

        public static implicit operator T(Result<T> source)
        {
            return source._inner;
        }
    }
}