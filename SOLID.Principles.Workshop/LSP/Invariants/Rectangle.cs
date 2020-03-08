namespace LSP.Invariants
{
    public class Rectangle
    {
        public virtual int Height { private get; set; }
        public virtual int Width { private get; set; }

        public int Area() => Height * Width;
    }
}
