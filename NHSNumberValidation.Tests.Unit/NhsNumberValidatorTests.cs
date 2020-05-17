using NUnit.Framework;

namespace NHSNumberValidation.Tests.Unit
{
    [TestFixture]

    public class NhsNumberValidatorTests
    {
        private NhsNumberValidator _nhsNumberValidator;

        [SetUp]
        public void SetUp()
        {
            _nhsNumberValidator = new NhsNumberValidator();
        }

        [TestCase("", false)]
        [TestCase("s99oi28088", false)]
        [TestCase("4856874", false)]
        [TestCase("5990128087", false)]
        [TestCase("4536016660", false)]
        [TestCase("5990128088", true)]
        [TestCase("1275988113", true)]
        [TestCase("4536026665", true)]
        public void NhsNumberIsValidTests(string nhsNumber, bool isValid)
        {
            Assert.AreEqual(isValid, _nhsNumberValidator.NhsNumberIsValid(nhsNumber));
        }
    }
}