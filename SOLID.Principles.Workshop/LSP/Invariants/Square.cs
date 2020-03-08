namespace LSP.Invariants
{
    public sealed class Square: Rectangle
    {
        public override int Height
        {
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }

        public override int Width
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }
}
