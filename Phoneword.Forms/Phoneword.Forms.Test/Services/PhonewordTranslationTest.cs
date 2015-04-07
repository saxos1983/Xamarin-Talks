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

        [TestCase("0190XAMARIN", "01909262746")]
        [TestCase("0-190-XAMARIN", "0-190-9262746")]
        [TestCase("01 90 XAMARIN", "01 90 9262746")]
        [TestCase("DOTNETROCKS", "36863876257")]
        [TestCase("0123456789", "0123456789")]
        public void ToNumericNumber_ShouldTranslateCorrectly(string alphanumericNumber, string expected)
        {
            // Act
            string result = this.testee.ToNumericNumber(alphanumericNumber);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}