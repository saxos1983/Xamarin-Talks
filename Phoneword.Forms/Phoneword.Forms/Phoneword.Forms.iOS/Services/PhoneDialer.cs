using Phoneword.Forms.iOS.Services;

using Xamarin.Forms;

// TODO Register this instance to the Dependecy Resolver Service.
[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.Forms.iOS.Services
{
    using Foundation;

    using Phoneword.Forms.Services;

    using UIKit;

    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}