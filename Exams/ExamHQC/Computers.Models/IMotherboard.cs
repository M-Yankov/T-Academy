namespace Computers.Models
{
    /// <summary>
    /// Delivers a contracts with RAM and displays a text.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads the current value from RAM.
        /// </summary>
        /// <returns>The value from RAM.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves a given value in the RAM.
        /// </summary>
        /// <param name="value">The to be saved.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Using video card to render a message text.
        /// </summary>
        /// <param name="data">Sting data to be processed.</param>
        void DrawOnVideoCard(string data);
    }
}
