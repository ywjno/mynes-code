namespace MyNes.Core.Debug.DefaultCommands
{
    class HardResetCommand : ConsoleCommand
    {
        public override string Method
        {
            get { return "hs"; }
        }

        public override string Description
        {
            get { return "Hard reset emulation"; }
        }

        public override void Execute(string parameters)
        {
            Nes.HardReset();
        }
    }
}
