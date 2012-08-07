namespace myNES.Core.IO.Output
{
    public interface IVideoDevice
    {
        /// <summary>
        /// Render a frame into the screen, the ppu calls this when the buffer is ready to be presented
        /// </summary>
        /// <param name="ScreenBuffer">The screen buffer, size = 256 * 240, each value is int32-ARBG color</param>
        void RenderFrame(int[][] ScreenBuffer);
        /// <summary>
        /// Begin the rendering operation, Ppu calls this at the beginning of the frame
        /// </summary>
        void Begin();
        /// <summary>
        /// Shutdown the device then dispose, emu calls this when it shutdown
        /// </summary>
        void Shutdown();
    }
}
