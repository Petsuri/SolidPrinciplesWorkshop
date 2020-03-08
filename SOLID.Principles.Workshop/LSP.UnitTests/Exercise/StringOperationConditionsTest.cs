using System;
using System.Collections.Generic;
using System.Text;
using LSP.Exercise;
using NUnit.Framework;

namespace LSP.UnitTests.Exercise
{
    public abstract class StringOperationConditionsTest
    {
        protected abstract IStringOperation GetTestFixture();

        [Test]
        public void Modifying_WithNullValue_ThrowsNullArgumentException()
        {
            var sut = GetTestFixture();

            Assert.Throws<ArgumentNullException>(() => sut.Modify(null));
        }

        [Test]
        public void Modifying_WithInputBeingTooLong_ThrowsArgumentException()
        {
            var sut = GetTestFixture();

            Assert.Throws<ArgumentException>(() => sut.Modify(new string('x', 1000)));
        }

        [Test]
        public void Modifying_WithEmptyValue_DoesNotThrowException()
        {
            var sut = GetTestFixture();

            Assert.DoesNotThrow(() => sut.Modify(""));
        }

        [Test]
        public void Modifying_WithOutputValueBeingTooLong_ThrowsException()
        {
            var sut = GetTestFixture();

            Assert.Throws<TooLongValueException>(() => sut.Modify(new string('x', 100)));
        }

    }
}
