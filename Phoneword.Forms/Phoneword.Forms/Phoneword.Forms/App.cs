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
            // TODO Resolve the appropriate IDialer instance for the corresponding target platform.
            var dialer = DependencyService.Get<IDialer>();
            var phonewordTranslator = DependencyService.Get<IPhonewordTranslator>();
            // TODO Resolve the appropriate ISpeech instance for the corresponding target platform.
            AppViewModel = new MainViewModel(dialer, phonewordTranslator);

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
