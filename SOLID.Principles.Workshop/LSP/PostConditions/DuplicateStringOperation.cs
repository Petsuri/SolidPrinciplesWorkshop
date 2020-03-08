using System;

namespace LSP.PostConditions
{
    public sealed class DuplicateStringOperation: IStringOperation
    {
        private readonly int _times;

        public DuplicateStringOperation(int times)
        {
            _times = times;
        }

        public string Modify(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            var modified = "";
            for (var i = 0; i < _times; i++)
            {
                modified += s;
            }

            if (modified.Length <= 1000)
            {
                return modified;
            }

            throw new InvalidOperationException("Modified string can't be over 1000 characters long");

        }
    }
}
