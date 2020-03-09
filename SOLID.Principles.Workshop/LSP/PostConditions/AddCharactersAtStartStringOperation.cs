using System;

namespace LSP.PostConditions
{
    public sealed class AddCharactersAtStartStringOperation: IStringOperation
    {
        private readonly string _characters;

        public AddCharactersAtStartStringOperation(string characters)
        {
            _characters = characters;
        }

        public string Modify(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            var modified = _characters + s;
            if (modified.Length <= 1100)
            {
                return modified;
            }

            throw new InvalidOperationException("Modified string can't be over 1100 characters long");

        }
    }
}
