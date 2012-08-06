namespace MyNes.Core.IO.Output
{
    public interface ISoundDevice
    {
        /// <summary>
        /// Emu calls this when it needs to update a frame
        /// </summary>
        void UpdateFrame();
        /// <summary>
        /// Shutdown the device then dispose, emu calls this when it shutdown
        /// </summary>
        void Shutdown();
    }
}
