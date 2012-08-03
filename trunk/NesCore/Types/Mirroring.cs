namespace MyNes.Core
{
    public enum Mirroring : byte
    {
        /// <summary>
        /// Vertical
        /// </summary>
        ModeVert = 0x11,
        /// <summary>
        /// Horizontal
        /// </summary>
        ModeHorz = 0x05,
        /// <summary>
        /// One screen - low
        /// </summary>
        Mode1ScA = 0x00,
        /// <summary>
        /// One screen - high
        /// </summary>
        Mode1ScB = 0x55,
        /// <summary>
        /// Four screen
        /// </summary>
        ModeFull = 0x1B,
    }
}
