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
        private SpeechMock speechMock;
        PhonewordTranslatorMock phonewordTranslator;
        PhoneTranslateViewModel translateViewModel;

        private const string AlphanumericPhoneNumber = "1-855-XAMARIN";
        private const string TranslatedPhoneNumber = "1-855-9262746";

        [SetUp]
        public void SetupViewModels()
        {
            dialer = new DialerMock();
            phonewordTranslator = new PhonewordTranslatorMock();
            speechMock = new SpeechMock();
            appViewModel = new MainViewModel(dialer, phonewordTranslator, speechMock);
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

        
        [Test]
        public void TestNoNarrateOnNotTranslatedNumber()
        {
            translateViewModel.TranslatedNumber = string.Empty;
            Assert.IsFalse(translateViewModel.SpeechCommand.CanExecute(null));
        }
        
        [Test]
        public void TestNarrationAllowedOnTranslatedNumber()
        {
            translateViewModel.PhoneNumberText = AlphanumericPhoneNumber;
            translateViewModel.TranslateCommand.Execute(null);
            Assert.IsTrue(translateViewModel.SpeechCommand.CanExecute(null));
        }

        [Test]
        public void TestPhoneNumberNarrated()
        {
            translateViewModel.PhoneNumberText = AlphanumericPhoneNumber;
            translateViewModel.TranslateCommand.Execute(null);
            translateViewModel.SpeechCommand.Execute(null);

            Assert.IsTrue(speechMock.CalledSpeech);
            Assert.AreEqual(speechMock.CalledTextToSpeech, "The translated number is 1 8 5 5 9 2 6 2 7 4 6 ");
        }
    }
}