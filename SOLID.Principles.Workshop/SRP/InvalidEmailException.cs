using System;

namespace SRP
{
    public class InvalidEmailException: Exception
    {
        public InvalidEmailException(string email): base(email)
        { }
    }
}
