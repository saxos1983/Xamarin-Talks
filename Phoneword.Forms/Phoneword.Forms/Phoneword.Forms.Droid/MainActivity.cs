using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Phoneword.Forms.Droid
{
    using Xamarin.Forms.Platform.Android;

    [Activity(Label = "Phoneword", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //SetPage(App.GetMainPage());
            this.LoadApplication(new App());
        }
    }
}

