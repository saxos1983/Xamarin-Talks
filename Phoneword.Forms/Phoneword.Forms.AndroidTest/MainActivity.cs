using System.Reflection;
using Android.App;
using Android.OS;
using Xamarin.Android.NUnitLite;

namespace Phoneword.Forms.AndroidTest
{
    [Activity(Label = "Phoneword.Forms.AndroidTest", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : TestSuiteActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // The tests are linked from the Unit Test project into this assembly
            // and then added to the runner.
            AddTest(Assembly.GetExecutingAssembly());

            // Once you called base.OnCreate(), you cannot add more assemblies.
            base.OnCreate(bundle);
        }
    }
}