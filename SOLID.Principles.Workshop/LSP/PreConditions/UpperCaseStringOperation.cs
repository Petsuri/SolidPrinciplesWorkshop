using System;

namespace LSP.PreConditions
{
    public sealed class UpperCaseStringOperation: IStringOperation
    {
        public string Modify(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            return s.ToUpper();
        }
    }
}
