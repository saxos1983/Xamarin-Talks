namespace Phoneword.Forms.Services
{
    // TODO Step 5: This interface needs to be implemented and registered in the platform specific projects.

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