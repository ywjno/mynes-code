namespace myNES.Core.Debug.DefaultCommands
{
    class SoftResetCommand : ConsoleCommand
    {
        public override string Method
        {
            get { return "sr"; }
        }

        public override string Description
        {
            get { return "Soft reset the emulation"; }
        }

        public override void Execute(string parameters)
        {
            Nes.SoftReset();
        }
    }
}
