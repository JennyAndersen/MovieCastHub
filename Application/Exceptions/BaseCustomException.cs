namespace Application.Exceptions
{
    public class BaseCustomException : Exception
    {
        public BaseCustomException() { }

        public BaseCustomException(string message) : base(message) { }

        public BaseCustomException(string message, Exception inner) : base(message, inner) { }
    }
}
