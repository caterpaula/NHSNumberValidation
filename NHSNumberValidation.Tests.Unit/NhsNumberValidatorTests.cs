using NUnit.Framework;

namespace NHSNumberValidation.Tests.Unit
{
    public class NhsNumberValidatorTests
    {
        private readonly NhsNumberValidator _nhsNumberValidator;
        public NhsNumberValidatorTests()
        {
            _nhsNumberValidator = new NhsNumberValidator();
        }

        [Theory]
        [TestCase("", false)]
        [TestCase("s99oi28088", false)]
        [TestCase("4856874", false)]
        [TestCase("5990128088", true)]
        [TestCase("1275988113", true)]
        [TestCase("4536026665", true)]
        [TestCase("5990128087", false)]
        [TestCase("4536016660", false)]
        public void NhsNumberIsValidTests(string nhsNumber, bool isValid)
        {
            Assert.AreEqual(isValid, _nhsNumberValidator.NhsNumberIsValid(nhsNumber));
        }
    }
}