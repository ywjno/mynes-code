namespace myNES.Core.IO.Output
{
    public abstract class VideoDevice : Component
    {
        /// <summary>
        /// Render a frame into the screen, the ppu calls this when the buffer is ready to be presented
        /// </summary>
        /// <param name="ScreenBuffer">The screen buffer, size = 256 * 240, each value is int32-ARBG color</param>
        public abstract void RenderFrame(int[][] ScreenBuffer);
        /// <summary>
        /// Begin the rendering operation, Ppu calls this at the beginning of the frame
        /// </summary>
        public abstract void Begin();
    }
}