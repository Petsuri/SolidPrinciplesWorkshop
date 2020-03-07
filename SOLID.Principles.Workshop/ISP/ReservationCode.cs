namespace ISP
{
    public sealed class ReservationCode
    {
        public string Value { get; }

        internal ReservationCode(string value)
        {
            Value = value;
        }
    }
}
