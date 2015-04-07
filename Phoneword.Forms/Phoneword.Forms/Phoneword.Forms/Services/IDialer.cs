namespace Phoneword.Forms.Services
{
    /// <summary>
    /// Abstraction for the dialing functionality.
    /// </summary>
    public interface IDialer
    {
        /// <summary>
        /// Dials the provided number.
        /// </summary>
        /// <param name="number">The number you want to perform a call.</param>
        bool Dial(string number);
    }
}