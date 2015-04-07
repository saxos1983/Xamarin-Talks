using Phoneword.Forms.iOS.Services;

using Xamarin.Forms;

// TODO Register this instance to the Dependecy Resolver Service.
[assembly: Dependency(typeof(Speech))]
namespace Phoneword.Forms.iOS.Services
{
    using AVFoundation;

    using Phoneword.Forms.Services;

    public class Speech : ISpeech
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            speechSynthesizer.SpeakUtterance(new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = .5f,
                PitchMultiplier = 1.0f
            });
        } 
    }
}