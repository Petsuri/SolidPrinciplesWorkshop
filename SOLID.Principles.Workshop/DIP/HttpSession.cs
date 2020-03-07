namespace DIP
{
    public sealed class HttpSession
    {
        public int UserId { get; }
        public int CompanyId { get; }

        public static HttpSession GetInstance()
        {
            return new HttpSession(0, 0);
        }

        private HttpSession(int userId, int companyId)
        {
            UserId = userId;
            CompanyId = companyId;
        }

    }
}
