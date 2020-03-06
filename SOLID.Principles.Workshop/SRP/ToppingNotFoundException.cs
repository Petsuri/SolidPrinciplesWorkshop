using System;

namespace SRP
{
    public sealed class ToppingNotFoundException: Exception
    {
        public ToppingNotFoundException(string topping): base(topping)
        { }
    }
}
