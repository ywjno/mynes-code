namespace myNES.Core.IO.Input
{
    public abstract class InputPort : Component
    {
        /// <summary>
        /// Update the controls, emu calls this when the controls state need to be updated
        /// </summary>
        public abstract void Update();
    }
}