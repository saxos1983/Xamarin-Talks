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

        [Test]
        public void TestPhoneNumberAllowsForTranslation()
        {
            translateViewModel.PhoneNumberText = AlphanumericPhoneNumber;
            Assert.IsTrue(translateViewModel.TranslateCommand.CanExecute(null));
        }

        [Test]
        public void TestPhoneNumberTranslates()
        {
            appViewModel.DialledNumbers.Clear();

            translateViewModel.PhoneNumberText = AlphanumericPhoneNumber;
            translateViewModel.TranslateCommand.Execute(null);
            translateViewModel.CallCommand.Execute(null);

            Assert.IsTrue(dialer.CalledDialer);
            Assert.AreEqual(dialer.LastDialedNumber, TranslatedPhoneNumber);

            Assert.IsTrue(appViewModel.DialledNumbers.Count == 1 &&
                appViewModel.DialledNumbers[0] == TranslatedPhoneNumber);
        }

        // TODO Step 9: We need some tests where we can check if the speech service was called correctly and with the proper text to be narrated.
    }
}