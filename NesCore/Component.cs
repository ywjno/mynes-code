using System.IO;

namespace myNES.Core
{
    public class Component
    {
        public virtual void Dispose() { }
        public virtual void Initialize() { }
        public virtual void HardReset() { }
        public virtual void SoftReset() { }
        public virtual void LoadState(BinaryReader reader) { }
        public virtual void SaveState(BinaryWriter writer) { }
    }
}