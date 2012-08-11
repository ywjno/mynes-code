namespace myNES.Core.IO.Output
{
    public interface IAudioDevice
    {
        /// <summary>
        /// Emu calls this when it needs to update a frame
        /// </summary>
        void Render();
        void Sample(short sample);
        /// <summary>
        /// Shutdown the device then dispose, emu calls this when it shutdown
        /// </summary>
        void Dispose();
    }
}