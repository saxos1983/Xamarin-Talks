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

        public MainViewModel(IDialer dialer, IPhonewordTranslator phonewordTranslator)
        {
            this.Dialer = dialer;
            this.PhonewordTranslator = phonewordTranslator;
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
            // TODO Step 5: Hmm... the translated phone number is not shown in the user interface.
            // I think we forgot to implement something.
        }
    }
}