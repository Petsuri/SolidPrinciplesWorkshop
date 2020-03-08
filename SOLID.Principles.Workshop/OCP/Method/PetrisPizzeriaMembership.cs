using System;

namespace OCP.Method
{
    public class PetrisPizzeriaMembership
    {
        private readonly Guid _id;
        private readonly DateTime? _expireTime;

        public PetrisPizzeriaMembership(Guid id, DateTime? expireTime)
        {
            _id = id;
            _expireTime = expireTime;
        }

        public bool HasExpired()
        {
            return _expireTime.HasValue &&
                   _expireTime < CurrentTime();
        }

        protected virtual DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}
