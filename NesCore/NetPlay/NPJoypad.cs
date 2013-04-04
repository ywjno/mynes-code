using MyNes.Core.IO.Input;
using System.Collections.Generic;
namespace MyNes.Core.NetPlay
{
    /// <summary>
    /// A joystick optimized for net play
    /// </summary>
    [System.Serializable()]
    public class NPJoypad : IJoypad
    {
        private byte data;
        public byte GetData()
        {
            return data;
        }
        /// <summary>
        /// Set joystick data to this joystick
        /// </summary>
        /// <param name="data"></param>
        public void SetData(byte data)
        {
            this.data = data;
        }
        public bool Turbo { get; set; }
    }
}
