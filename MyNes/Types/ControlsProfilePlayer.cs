namespace MyNes
{
    public class ControlsProfilePlayer
    {
        private string _A;
        private string _B;
        private string _Left;
        private string _Right;
        private string _Up;
        private string _Down;
        private string _Start;
        private string _Select;

        public string A
        { get { return _A; } set { _A = value; } }
        public string B
        { get { return _B; } set { _B = value; } }
        public string Left
        { get { return _Left; } set { _Left = value; } }
        public string Right
        { get { return _Right; } set { _Right = value; } }
        public string Up
        { get { return _Up; } set { _Up = value; } }
        public string Down
        { get { return _Down; } set { _Down = value; } }
        public string Start
        { get { return _Start; } set { _Start = value; } }
        public string Select
        { get { return _Select; } set { _Select = value; } }
    }
}
