using System;

namespace OCP.Method
{
    public class TestingPetrisPizzeriaMembership : PetrisPizzeriaMembership
    {
        private DateTime _currentTime = new DateTime(2000, 1, 1);

        public TestingPetrisPizzeriaMembership(Guid id, DateTime? expireTime) : base(id, expireTime)
        {
        }

        public TestingPetrisPizzeriaMembership WithCurrentTime(DateTime currentTime)
        {
            _currentTime = currentTime;
            return this;
        }

        protected override DateTime CurrentTime()
        {
            return _currentTime;
        }
    }
}
