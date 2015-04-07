using System.Linq;

using Android.App;
using Android.Content;

using Phoneword.Forms.Droid.Services;

using Xamarin.Forms;

// TODO Step 5: Register the appropriate IDialer instance for the corresponding target platform.
// You could do this with any Inversion of Control Container (like Autofac, Ninject, TinyIoc, ...)
// To keep it simple, try to register it with the builtin DepencyService of Xamarin.Forms
// http://developer.xamarin.com/guides/cross-platform/xamarin-forms/dependency-service/
namespace Phoneword.Forms.Droid.Services
{
    using Android.Telephony;

    using Phoneword.Forms.Services;

    public class PhoneDialer : IDialer
    {
        public static Activity Activity { get; set; }

        public bool Dial(string number)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + number));

            if (IsIntentAvailable(Xamarin.Forms.Forms.Context, intent))
            {
                Xamarin.Forms.Forms.Context.StartActivity(intent);
                return true;
            }

            return false;
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));
            if (list.Any())
                return true;

            var mgr = TelephonyManager.FromContext(context);
            return mgr.PhoneType != PhoneType.None;
        }
    }
}