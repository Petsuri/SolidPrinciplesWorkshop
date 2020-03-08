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
            if (modified.Length <= 1000)
            {
                return modified;
            }

            return modified.Substring(0, 1000);

        }
    }
}
