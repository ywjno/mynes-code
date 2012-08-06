using System.Drawing;
using System.Windows.Forms;

namespace MyNes.Forms
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, System.EventArgs e)
        {
            base.ClientSize = new Size(256, 240);
        }
    }
}