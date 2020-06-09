using Airport.GameModel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Airport.CustomDialogs
{
    public partial class ComboboxDialog : Form
    {
        private bool cancel = false;

        public City SelectedCity { get; private set; }

        public bool PressCancel { get { return cancel; } }

        public ComboboxDialog(List<City> cities)
        {
            InitializeComponent();
            foreach (City city in cities)
                citiesCB.Items.Add(city);
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            SelectedCity = (City)citiesCB.SelectedItem;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            SelectedCity = null;
            cancel = true;
            this.Close();
        }
    }
}
