using System.Windows.Forms;
namespace MyNes
{
    public class InputSettingsControl : UserControl
    {
        public virtual void SaveSettings()
        {

        }
        public virtual void DefaultSettings()
        {

        }
        /// <summary>
        /// Rised when the user select this settings control
        /// </summary>
        public virtual void OnSettingsSelect()
        {

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
