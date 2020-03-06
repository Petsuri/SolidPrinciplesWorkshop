using System;

namespace SRP
{
    public sealed class PizzaNotFoundException: Exception
    {
        public PizzaNotFoundException(string name): base(name) 
        { }
    }
}
