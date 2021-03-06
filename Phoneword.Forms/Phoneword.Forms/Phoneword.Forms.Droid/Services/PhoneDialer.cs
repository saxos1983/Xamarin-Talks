using System.Linq;

using Android.App;
using Android.Content;

using Phoneword.Forms.Droid.Services;

using Xamarin.Forms;

// TODO Register this instance to the Dependecy Resolver Service.
[assembly: Dependency(typeof(PhoneDialer))]
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