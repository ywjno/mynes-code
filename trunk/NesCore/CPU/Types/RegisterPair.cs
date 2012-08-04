namespace MyNes.Core
{
    abstract class RegisterPair
    {
        byte low;
        byte high;

        public virtual byte Low
        { get { return low; } set { low = value; } }
        public virtual byte High
        { get { return high; } set { high = value; } }
        public virtual int Value
        {
            get { return ((high << 8) | low); }
            set 
            {
                high = (byte)((value & 0xFF00) >> 8);
                low = (byte)((value & 0xFF));
            }
        }
    }
}
