using MyNes.Core.IO.Input;
namespace MyNes
{
    public class Zapper : IZapper
    {
        public Zapper(RendererFormSlimDX renderer)
        {
            this.renderer = renderer;
        }
        private RendererFormSlimDX renderer;
        public bool trigger = false;
        public bool lightDetected = false;
        public bool Trigger
        {
            get
            {
                return trigger;
            }
        }

        public bool LightDetected
        {
            get
            {
                lightDetected = renderer.DetectZapperLight();
                return !lightDetected;
            }
        }
    }
}
