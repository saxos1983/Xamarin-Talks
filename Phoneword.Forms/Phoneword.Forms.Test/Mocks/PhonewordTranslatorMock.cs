namespace Phoneword.Forms.Test.Mocks
{
    using Phoneword.Forms.Services;

    public class PhonewordTranslatorMock : IPhonewordTranslator
    {
        public string ToNumericNumber(string alphanumericNumber)
        {
            return "1-855-XAMARIN";
        }
    }
}