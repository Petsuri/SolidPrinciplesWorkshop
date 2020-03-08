using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Invariants
{
    public sealed class Client
    {
        public void Run()
        {
            var square = new Square();
            Modify(square);
        }

        private void Modify(Rectangle rectangle)
        {
            rectangle.Width = 20;
            rectangle.Height = 50;

            if (rectangle.Area() != 1000)
            {
                throw new InvalidOperationException("Rectangle invariant violated");
            }
        }
    }
}
