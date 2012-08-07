namespace myNES.Core.Debug.DefaultCommands
{
    class OffCommand : ConsoleCommand
    {
        public override string Method
        {
            get { return "off"; }
        }

        public override string Description
        {
            get { return "Turn the emulation off"; }
        }

        public override void Execute(string parameters)
        {
            Nes.Shutdown();
        }
    }
}
