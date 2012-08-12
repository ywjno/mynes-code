namespace myNES.Core.IO.Input
{
    public abstract class InputDevice
    {
        /// <summary>
        /// Get the data of pressed buttons
        /// </summary>
        /// <returns>The data</returns>
        public abstract byte GetData();
    }
}