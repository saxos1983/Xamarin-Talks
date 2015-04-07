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

        // TODO Step 9: Add a new speech command, which will call the text to speech service.

        MainViewModel _appViewModel;

        public PhoneTranslateViewModel(MainViewModel appViewModel)
        {
            _appViewModel = appViewModel;

            _translateCommand = new DelegateCommand(DoTranslate, () => !String.IsNullOrEmpty(PhoneNumberText));
            _callCommand = new DelegateCommand(DoCall, () => !String.IsNullOrEmpty(TranslatedNumber));
            _callHistoryCommand = new DelegateCommand(DoCallHistory); //, () => App.AppViewModel.DialledNumbers.Count > 0);
            // TODO Step 9: Initialize the speech command with the appropriate delegate.
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
            // TODO Step 9: Update if the speech command can be executed.
        }

        // TODO Step 9: Create a delegate which will narrate the translated number.
        // Keep in mind that we dont want to narrate allowed characters like '-' or spaces.
        // Strip those characters out in a helper method, extension method, or whatever you like.

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