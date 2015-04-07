namespace Phoneword.Forms.Test.Services
{
    using NUnit.Framework;

    using Phoneword.Forms.Services;

    [TestFixture]
    public class PhonewordTranslatorTest
    {
        IPhonewordTranslator testee;
        [SetUp]
        public void SetUp()
        {
            this.testee = new PhonewordTranslator();
        }

        // TODO Step 3a: The test will fail. Please have a look in the specification for the desired behaviour and write the tests FIRST
        // (Test Driven Development approach) before you start implementing PhonewordTranslator!
        // Try to cover all special cases in your tests.

        [Test]
        public void ToNumericNumber_ShouldTranslateCorrectly()
        {
            // Arrange
            string alphanumericNumber = "0-190-XAMARIN";
            string translatedNumber = "0-190-9262746";

            // Act
            string result = this.testee.ToNumericNumber(alphanumericNumber);

            // Assert
            Assert.AreEqual(translatedNumber, result);
        }
    }
}