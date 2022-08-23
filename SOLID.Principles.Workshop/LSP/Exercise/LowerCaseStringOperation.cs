using System;

namespace LSP.Exercise
{
    public sealed class LowerCaseStringOperation : IStringOperation
    {
        private const int MaxAllowedInputStringLength = 1000;
        private const int MaxAllowedOutputStringLength = 100;
        
        public string Modify(string s)
        {
            CheckPreconditions(s);

            var returnValue = s.ToLower();

            CheckPostConditions(returnValue);

            return returnValue;
        }

        private static void CheckPreconditions(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (s.Length >= MaxAllowedInputStringLength)
            {
                throw new ArgumentException("Maximum allowed string length: " + MaxAllowedInputStringLength, nameof(s));
            }
        }

        private static void CheckPostConditions(string returnValue)
        {
            if (returnValue.Length >= MaxAllowedOutputStringLength)
            {
                throw new TooLongValueException();
            }
        }
    }
}