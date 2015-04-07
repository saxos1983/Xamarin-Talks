using Phoneword.Forms.Droid.Services;

using Xamarin.Forms;

// TODO Register this instance to the Dependecy Resolver Service.
[assembly: Dependency(typeof(Speech))]
namespace Phoneword.Forms.Droid.Services
{
    using System.Collections.Generic;

    using Android.App;
    using Android.Speech.Tts;

    using Phoneword.Forms.Services;

    public class Speech : Java.Lang.Object, ISpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speech;
        string lastText;

        public void Speak(string text)
        {
            if (speech == null)
            {
                lastText = text;
                speech = new TextToSpeech(Application.Context, this);
            }
            else
            {
                speech.Speak(text, QueueMode.Flush, new Dictionary<string, string>());
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                speech.Speak(lastText, QueueMode.Flush, new Dictionary<string, string>());
                lastText = null;
            }
        }
    }
}