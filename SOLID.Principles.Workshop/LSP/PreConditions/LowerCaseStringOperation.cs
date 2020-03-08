using System;

namespace LSP.PreConditions
{
    public sealed class LowerCaseStringOperation: IStringOperation
    {
        public string Modify(string s)
        {
            if (s == null)
            {
                return string.Empty;
            }

            return s.ToLower();
        }
    }
}
