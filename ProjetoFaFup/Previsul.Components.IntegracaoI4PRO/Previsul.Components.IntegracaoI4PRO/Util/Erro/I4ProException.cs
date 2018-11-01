using System;

namespace Application.Integration.I4Pro
{
    public class I4ProException : Exception
    {
        public I4ProException(string message)
            : base(message)
        {
        }

        public I4ProException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
