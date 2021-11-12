using System;

namespace OCP.Method
{
    public class TestingPetrisPizzeriaMembership : PetrisPizzeriaMembership
    {
        private readonly DateTime _currentTime = new DateTime(2000, 1, 1);

        public TestingPetrisPizzeriaMembership(Guid id, DateTime? expireTime, DateTime? currentTime = null) : base(id, expireTime)
        {
            _currentTime = currentTime ?? _currentTime;
        }

        protected override DateTime CurrentTime()
        {
            return _currentTime;
        }
    }
}
