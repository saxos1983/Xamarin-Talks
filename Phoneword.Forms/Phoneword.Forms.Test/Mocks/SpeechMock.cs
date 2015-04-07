namespace Phoneword.Forms.Test.Mocks
{
    using Phoneword.Forms.Services;

    public class SpeechMock : ISpeech
    {
        public bool CalledSpeech = false;
        public string CalledTextToSpeech = null;

        public void Speak(string text)
        {
            this.CalledSpeech = true;
            this.CalledTextToSpeech = text;
        }
    }
}