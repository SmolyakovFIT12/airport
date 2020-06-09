using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Airport.GameViewController;

namespace Airport
{
    [System.Serializable]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UserScroll : UserControl, IContainerControl
    {

        public UserScroll()
        {
            InitializeComponent();
            BackColor = MainForm.MostlyBackColor;
            panelAll.BackColor = MainForm.MostlyBackColor;
        }

        public override string Text
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        // x - горизонталь, y - вертикаль
        public void SetLocation(int x, int y)
        {
            Location = new Point(x, y);
        }

        public Panel GetPanel
        {
            get { return panelAll; }
        }
    }
}
