using Phoneword.Forms.iOS.Services;

using Xamarin.Forms;

// TODO Step 5: Register the appropriate IDialer instance for the corresponding target platform.
// You could do this with any Inversion of Control Container (like Autofac, Ninject, TinyIoc, ...)
// To keep it simple, try to register it with the builtin DepencyService of Xamarin.Forms
// http://developer.xamarin.com/guides/cross-platform/xamarin-forms/dependency-service/
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