namespace Phoneword.Forms.ViewModels
{
    using System.Collections.ObjectModel;

    using Phoneword.Forms.Services;
    using Phoneword.Forms.Utility;

    public class MainViewModel : ViewModel
    {
        public IDialer Dialer
        {
            get;
            set;
        }

        public IPhonewordTranslator PhonewordTranslator { get; set; }

        public ISpeech Speech { get; set; }

        public MainViewModel(IDialer dialer, IPhonewordTranslator phonewordTranslator, ISpeech speech)
        {
            this.Dialer = dialer;
            this.PhonewordTranslator = phonewordTranslator;
            this.Speech = speech;
        }

        ObservableCollection<string> _dialledNumbers = new ObservableCollection<string>();

        public ObservableCollection<string> DialledNumbers
        {
            get { return _dialledNumbers; }
            set
            {
                if (_dialledNumbers != value)
                {
                    _dialledNumbers = value;
                    RaisePropertyChanged("DialledNumbers");
                }
            }
        }

        public void LogPhoneNumber(string phoneNumber)
        {
            DialledNumbers.Add(phoneNumber);
        }
    }
}