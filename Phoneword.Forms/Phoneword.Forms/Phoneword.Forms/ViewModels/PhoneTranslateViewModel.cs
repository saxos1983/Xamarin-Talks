namespace Phoneword.Forms.ViewModels
{
    using System;
    using System.Text;
    using System.Windows.Input;

    using Phoneword.Forms.Services;
    using Phoneword.Forms.Utility;

    public class PhoneTranslateViewModel : ViewModel
    {
        DelegateCommand _translateCommand;

        public ICommand TranslateCommand
        {
            get { return _translateCommand; }
        }

        DelegateCommand _callCommand;

        public ICommand CallCommand
        {
            get { return _callCommand; }
        }

        private DelegateCommand _callHistoryCommand;

        public ICommand CallHistoryCommand
        {
            get { return _callHistoryCommand; }
        }


        private DelegateCommand _speechCommand;

        public ICommand SpeechCommand
        {
            get { return _speechCommand; }
        }

        MainViewModel _appViewModel;

        public PhoneTranslateViewModel(MainViewModel appViewModel)
        {
            _appViewModel = appViewModel;

            _translateCommand = new DelegateCommand(DoTranslate, () => !String.IsNullOrEmpty(PhoneNumberText));
            _callCommand = new DelegateCommand(DoCall, () => !String.IsNullOrEmpty(TranslatedNumber));
            _callHistoryCommand = new DelegateCommand(DoCallHistory); //, () => App.AppViewModel.DialledNumbers.Count > 0);
            _speechCommand = new DelegateCommand(DoSpeechNumber, () => !String.IsNullOrEmpty(PhoneNumberText));
        }

        private string _phoneNumberText = "";

        public string PhoneNumberText
        {
            get { return _phoneNumberText; }
            set
            {
                if (_phoneNumberText != value)
                {
                    _phoneNumberText = value;
                    RaisePropertyChanged("PhoneNumberText");
                    _translateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _translatedNumber = String.Empty;

        public string TranslatedNumber
        {
            get { return _translatedNumber; }
            set
            {
                if (_translatedNumber != value)
                {
                    _translatedNumber = value;
                    RaisePropertyChanged("TranslatedNumber");
                    RaisePropertyChanged("CallButtonDisplay");
                }
            }
        }

        public string CallButtonDisplay
        {
            get
            {
                if (String.IsNullOrEmpty(_translatedNumber))
                    return "Call";
                else
                {
                    return "Call " + _translatedNumber;
                }
            }
        }
        private void DoTranslate()
        {
            // TODO Perform the translate operation
            TranslatedNumber = new PhonewordTranslator().ToNumericNumber(_phoneNumberText);
            _callCommand.RaiseCanExecuteChanged();
            _speechCommand.RaiseCanExecuteChanged();
        }

        private void DoSpeechNumber()
        {
            var messageToSpeak = "The translated number is " + this.GetOnlyNumbers(_translatedNumber);
            _appViewModel.Speech.Speak(messageToSpeak);
        }

        private string GetOnlyNumbers(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return "unknown";
            }
            
            var onlyNumbers = number.Replace("-", "").Replace(" ", "");

            StringBuilder builder = new StringBuilder(onlyNumbers.Length * 2);
            foreach (char c in onlyNumbers)
            {
                builder.Append(c);
                builder.Append(' ');
            }
            string result = builder.ToString();
            return result;
        }

        public Action<string> CallFailed = delegate { };

        private void DoCall()
        {
            bool couldCall = false;

            try
            {
                _appViewModel.LogPhoneNumber(_translatedNumber);

                couldCall = _appViewModel.Dialer.Dial(_translatedNumber);
            }
            catch (Exception e)
            {
                couldCall = false;
            }

            if (!couldCall)
            {
                CallFailed(_translatedNumber);
            }
        }

        public Action ShowCallHistoryDisplay = delegate { };

        private void DoCallHistory()
        {
            ShowCallHistoryDisplay();
        }
    }
}