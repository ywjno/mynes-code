namespace myNES.Core.Types
{
    public class Mirroring
    {
        /// <summary>
        /// [ A ][ A ]
        /// [ A ][ A ]
        /// </summary>
        public const int Mode1ScA = 0x0;
        /// <summary>
        /// [ B ][ B ]
        /// [ B ][ B ]
        /// </summary>
        public const int Mode1ScB = 0xF;
        /// <summary>
        /// [ A ][ B ]
        /// [ A ][ B ]
        /// </summary>
        public const int ModeVert = 0x5;
        /// <summary>
        /// [ A ][ A ]
        /// [ B ][ B ]
        /// </summary>
        public const int ModeHorz = 0x3;
    }
}