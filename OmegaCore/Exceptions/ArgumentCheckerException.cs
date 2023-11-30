using System.Runtime.Serialization;

namespace OmegaCore.Exceptions
{
    public class ArgumentCheckerException : Exception, ISerializable
    {
        public new const string Message = "Argument is not valid!";

        public ArgumentCheckerException() : base(Message) { }

        public ArgumentCheckerException(string message) : base(message ?? Message) { }

        public ArgumentCheckerException(string message, Exception innerException) : base(message ?? Message, innerException) { }

        public static void CheckSourceGreaterThanOther(int source, int other, string paramName)
        {
            if (source > other)
                throw new ArgumentCheckerException($"source param with name: {paramName} must not be greater than other. Source:{source} > Other{other}!");
        }

        public static void CheckSourceGreaterOrEqualThanOther(int source, int other, string paramName)
        {
            if (source >= other)
                throw new ArgumentCheckerException($"source param with name: {paramName} must not be greater or equal than other. Source:{source} >= Other{other}!");
        }

        public static void CheckSourceLessThanOther(int source, int other, string paramName)
        {
            if (source < other)
                throw new ArgumentCheckerException($"source param with name: {paramName} must not be less than other. Source:{source} < Other{other}!");
        }

        public static void CheckSourceLessOrEqualThanOther(int source, int other, string paramName)
        {
            if (source <= other)
                throw new ArgumentCheckerException($"source param with name: {paramName} must not be less or equal than other. Source:{source} <= Other{other}!");
        }
    }
}