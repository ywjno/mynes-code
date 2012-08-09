namespace myNES.Core.IO.Input
{
    public interface IJoypad
    {
        /// <summary>
        /// Get the data of pressed buttons
        /// </summary>
        /// <returns>The data</returns>
        byte GetData();
    }
}

