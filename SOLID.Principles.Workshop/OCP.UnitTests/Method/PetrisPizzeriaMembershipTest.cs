using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OCP.Method;

namespace OCP.UnitTests.Method
{
    public class PetrisPizzeriaMembershipTest
    {
        [Test]
        public void HasExpired_WithExpireTimeNotSet_IsFalse()
        {
            var sut = new PetrisPizzeriaMembership(Guid.Empty, null);

            var actual = sut.HasExpired();

            Assert.IsFalse(actual);
        }

        [Test]
        public void HasExpired_WithExpireTimeNotPassed_IsFalse()
        {
            var sut = new PetrisPizzeriaMembership(Guid.Empty, new DateTime(2020, 1, 1));

            var actual = sut.HasExpired();

            Assert.IsFalse(actual);
        }

        [Test]
        public void HasExpired_WithExpireTimeBeingCurrentTime_IsFalse()
        {
            var sut = new PetrisPizzeriaMembership(Guid.Empty, new DateTime(2020, 2, 1));

            var actual = sut.HasExpired();

            Assert.IsFalse(actual);
        }

        [Test]
        public void HasExpired_WithExpireTimeBeingPassed_IsTrue()
        {
            var sut = new PetrisPizzeriaMembership(Guid.Empty, new DateTime(2020, 4, 1));

            var actual = sut.HasExpired();

            Assert.IsTrue(actual);
        }

    }
}
