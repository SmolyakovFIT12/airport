using System.ComponentModel;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Drawing;
using Airport.GameViewController;

namespace Airport
{
    [System.Serializable]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UserBoard : UserControl, IContainerControl
    {

        public UserBoard()
        {
            InitializeComponent();
            BackColor = MainForm.MostlyBackColor;
            panelAll.BackColor = MainForm.MostlyBackColor;
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
