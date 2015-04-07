using Phoneword.Forms.Services;

using Xamarin.Forms;

// TODO Step 4: Register the appropriate IPhonewordTranslator instance for the corresponding target platform.
// You could do this with any Inversion of Control Container (like Autofac, Ninject, TinyIoc, ...)
// To keep it simple, try to register it with the builtin DepencyService of Xamarin.Forms
// http://developer.xamarin.com/guides/cross-platform/xamarin-forms/dependency-service/
namespace Phoneword.Forms.Services
{
    using System.Text;

    /// <inheritdoc />
    public class PhonewordTranslator : IPhonewordTranslator
    {
        // TODO Step 3b: Implement the translation of the alphanumeric phone number to the numeric phone number correctly.
        // The requirements are the following:
        // -    The letters should be converted to the following numbers:
        //          a, b, c	        --> 2
        //          d, e, f	        --> 3
        //          g, h, i	        --> 4
        //          j, k, l	        --> 5
        //          m, n, o	        --> 6
        //          p, q, r, s	    --> 7
        //          t, u, v	        --> 8
        //          w, x, y, z	    --> 9
        // -	Lower and uppercase letters should be handed similarly.
        // -	Spaces and dashes should be allowed (e.g. 0190 555-222-1 is valid).
        // -	Other or Special Characters should be skipped.

        /// <inheritdoc />
        public string ToNumericNumber(string alphanumericNumber)
        {
            return alphanumericNumber;
        }
    }
}