using Phoneword.Forms.Services;

using Xamarin.Forms;

[assembly: Dependency(typeof(PhonewordTranslator))]
namespace Phoneword.Forms.Services
{
    using System.Text;

    /// <inheritdoc />
    public class PhonewordTranslator : IPhonewordTranslator
    {
        /// <inheritdoc />
        public string ToNumericNumber(string alphanumericNumber)
        {
            if (string.IsNullOrWhiteSpace(alphanumericNumber))
                return string.Empty;

            var newNumber = new StringBuilder();
            foreach (char c in alphanumericNumber.ToUpperInvariant())
            {
                if (Contains(" -0123456789", c))
                    newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        newNumber.Append(result);
                }
                // Otherwise we skipped a special character.
            }

            return newNumber.ToString();
        }

        private static bool Contains(string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        private static int? TranslateToNumber(char c)
        {
            if (Contains("ABC", c))
                return 2;
            else if (Contains("DEF", c))
                return 3;
            else if (Contains("GHI", c))
                return 4;
            else if (Contains("JKL", c))
                return 5;
            else if (Contains("MNO", c))
                return 6;
            else if (Contains("PQRS", c))
                return 7;
            else if (Contains("TUV", c))
                return 8;
            else if (Contains("WXYZ", c))
                return 9;
            return null;
        }
    }
}