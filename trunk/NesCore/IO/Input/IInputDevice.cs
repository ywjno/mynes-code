namespace myNES.Core.IO.Input
{
    public interface IInputDevice
    {
        /// <summary>
        /// Update the controls, emu calls this when the controls state need to be updated
        /// </summary>
        void Update();
    }
}
