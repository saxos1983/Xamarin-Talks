namespace Phoneword.Forms.Test.Mocks
{
    using Phoneword.Forms.Services;

    public class DialerMock : IDialer
    {
        public string LastDialedNumber = null;
        public bool CalledDialer = false;

        public bool Dial(string number)
        {
            CalledDialer = true;
            LastDialedNumber = number;
            return true;
        }
    }
}
