// using _05_ByteBank;

using System;
using System.Runtime.Serialization;

namespace ByteBank
{
    [Serializable]
    internal class DivideByZerException : Exception
    {
        public DivideByZerException()
        {
        }

        public DivideByZerException(string message) : base(message)
        {
        }

        public DivideByZerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DivideByZerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}