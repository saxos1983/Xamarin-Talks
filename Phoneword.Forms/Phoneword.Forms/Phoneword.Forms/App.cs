using Xamarin.Forms;

namespace Phoneword.Forms
{
    using Phoneword.Forms.Services;
    using Phoneword.Forms.ViewModels;
    using Phoneword.Forms.Views;

    public class App : Application
    {
        public static MainViewModel AppViewModel = null;

        public App()
        {
            // TODO Step 4: Resolve the appropriate IPhonewordTranslator instance for the corresponding target platform.
            // TODO Step 5: Resolve the appropriate IDialer instance for the corresponding target platform.
            // TODO Step 9: Resolve the appropriate ISpeech instance for the corresponding target platform.

            // Hint: Registering and resolving dependencies can be made in many different ways and frameworks.
            // You could do this with any Inversion of Control Container (like Autofac, Ninject, TinyIoc, ...)
            // To keep it simple, try to resolve it with the builtin DepencyService of Xamarin.Forms
            // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/dependency-service/

            AppViewModel = new MainViewModel(null, null); // <-- Bam, passing null parameters. Bad boy.

            MainPage = new NavigationPage(new PhoneTranslatePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
