namespace myNES.Core.IO.Output
{
    public abstract class AudioDevice : Component
    {
        /// <summary>
        /// Emu calls this when it needs to update a frame
        /// </summary>
        public abstract void Render();
        public abstract void Sample(short sample);
    }
}