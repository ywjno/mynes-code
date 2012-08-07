namespace myNES.Core
{
    /// <summary>
    /// Class represent My Nes console command
    /// </summary>
    public abstract class ConsoleCommand
    {
        /// <summary>
        /// Get the method of this command
        /// </summary>
        public abstract string Method { get; }
        /// <summary>
        /// Get the description of this command
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Get the parameters that accepted
        /// </summary>
        public virtual string[] Parameters { get { return new string[0]; } }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameters">The parameters if this command have parameters</param>
        public abstract void Execute(string parameters);
    }
}