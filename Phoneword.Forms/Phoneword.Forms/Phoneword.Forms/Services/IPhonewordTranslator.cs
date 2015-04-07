namespace Phoneword.Forms.Services
{
    /// <summary>
    /// Phoneword translator, which provides functions to translate phone numbers.
    /// </summary>
    public interface IPhonewordTranslator
    {
        /// <summary>
        /// Translate a alphanumeric number to a numeric number.
        /// </summary>
        /// <returns>The numeric number.</returns>
        /// <param name="alphanumericNumber">Alphanumeric number to be translat-ed.</param>
        string ToNumericNumber(string alphanumericNumber);
    }
}