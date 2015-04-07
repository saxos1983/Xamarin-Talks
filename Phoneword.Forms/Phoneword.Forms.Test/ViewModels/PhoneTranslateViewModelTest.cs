namespace Phoneword.Forms.Test.ViewModels
{
    using NUnit.Framework;

    using Phoneword.Forms.Test.Mocks;
    using Phoneword.Forms.ViewModels;

    [TestFixture]
    public class TestPhoneTranslateViewModel
    {
        MainViewModel appViewModel;
        DialerMock dialer;
        // TODO Step 9: For later we will need a speech service mock to be able to run tests if the speech service was called correctly.
        PhonewordTranslatorMock phonewordTranslator;
        PhoneTranslateViewModel translateViewModel;

        private const string AlphanumericPhoneNumber = "1-855-XAMARIN";
        private const string TranslatedPhoneNumber = "1-855-9262746";

        [SetUp]
        public void SetupViewModels()
        {
            dialer = new DialerMock();
            phonewordTranslator = new PhonewordTranslatorMock();
            appViewModel = new MainViewModel(dialer, phonewordTranslator);
            translateViewModel = new PhoneTranslateViewModel(appViewModel);
        }

        [Test]
        public void TestNoTranslateOnEmptyText()
        {
            translateViewModel.PhoneNumberText = string.Empty;
            Assert.IsFalse(translateViewModel.TranslateCommand.CanExecute(null));
        }

        // TODO Step 7: We have only one basic test which checks that the Translate Command can not be executed when the entered phone number is empty.
        // Please add more tests for the this ViewModel tests.
        // Candidates are:
        // - When a phone number is entered the Translate Command can be executed.
        // - When the phone number is translated check chat the translation is correct.
        // - When the phone number is translated check that the translated number is added in the call history.
        // - many many more.

        // TODO Step 9: We need some tests where we can check if the speech service was called correctly and with the proper text to be narrated.
    }
}