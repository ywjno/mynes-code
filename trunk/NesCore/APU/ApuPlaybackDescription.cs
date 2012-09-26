namespace MyNes.Core.APU
{
    public struct ApuPlaybackDescription
    {
        public ApuPlaybackDescription(int frequency, ApuMixerType type)
        {
            this.frequency = frequency;
            this.type = type;
        }
        private int frequency;
        private ApuMixerType type;

        public int Frequency
        { get { return frequency; } }
        public ApuMixerType MixerType
        { get { return type; } }
    }
    public enum ApuMixerType
    {
        Normal, Implementation, LinearApproximation
    }
}
