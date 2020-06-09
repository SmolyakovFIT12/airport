using Airport.GameLogicInterface;
using Airport.GameModel;
using Airport.GameViewController;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airport
{
    [Serializable]
    public partial class ContractData : UserControl
    {
        Contract contract;
        private Flight flight;
        public uint FlightNum => flight.Number;
        IGameLogicInteractable game;
        ContractForm newForm;

        public ContractData(bool isPassenger, IGameLogicInteractable game, Contract contract, Flight flight)
        {
            InitializeComponent();

            this.game = game;
            this.flight = flight;
            this.contract = contract;

            BackColor = MainForm.MostlyBackColor;
            btnDo.BackColor = MainForm.MostlyBackColor;
            btnDelete.BackColor = MainForm.MostlyBackColor;
            btnDelete.FlatStyle = FlatStyle.Flat;
            if (isPassenger)
            {
                lblType.Text = "Пассажиры:";
                lblType.Width = 109;
                lblTypeValue.Location = new Point(124, 80);
                lblTime.Visible = false;
                lblTimeValue.Visible = false;
            }
            else
            {
                lblType.Text = "Грузоподъемность:";
                lblType.Width = 175;
                lblTypeValue.Location = new Point(190, 80);
                lblTime.Visible = false;
                lblTimeValue.Visible = false;
            }

            newForm = new ContractForm(this.game, this.contract, flight.Number);
        }

        public string FlightName
        {
            get { return lblFlightName.Text; }
            set
            {
                lblFlightName.Text = value;
            }
        }

        public string TypeValue
        {
            get { return lblTypeValue.Text; }
            set
            {
                lblTypeValue.Text = value;
            }
        }

        public DateTime DateValue
        {
            get { return DateTime.Parse(lblDateValue.Text); }
            set
            {
                lblDateValue.Text = value.ToLongDateString();
            }
        }

        public string StatusValue
        {
            get { return lblStatusValue.Text; }
            set
            {
                lblStatusValue.Text = value.ToString();
            }
        }

        public TimeSpan TimeValue
        {
            get
            {
                string[] time = lblTimeValue.Text.Replace(" ч", "").Replace(" мин", "").Split(' ');
                return new TimeSpan(int.Parse(time[0]), int.Parse(time[1]), 0);
            }
            set
            {
                lblTimeValue.Text = (value.Hours == 0 ? "" : value.Hours.ToString() + " ч ") +
                    value.Minutes.ToString() + " мин ";
                bool finished = value.Days == 0 && value.Hours == 0 && value.Minutes == 0;
                btnDelete.Visible = finished;
                btnDelete.Enabled = finished;
                btnDo.Visible = finished;
                btnDo.Enabled = finished;
                lblTimeValue.Visible = !finished;
                StatusValue = finished ? "готов" : "в процессе";
            }
        }

        public event EventHandler OnActionDo
        {
            add { btnDo.Click += value; }
            remove { btnDo.Click -= value; }
        }

        public event EventHandler OnActionDelete
        {
            add { btnDelete.Click += value; }
            remove { btnDelete.Click -= value; }
        }

        private void BtnDo_Click(object sender, EventArgs e)
        {
            newForm.UpdatePlanesContract();
            newForm.ShowDialog();
            StatusValue = newForm.IsSuccessful ? "готов" : "не готов";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"При отказе от рейса вы можете потерять следующую сумму: " +
                $"{contract.Forfeit * contract.ConnectedFlights.Count}. Продолжить?", 
                "Возможны убытки", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            foreach (Flight flight in contract.ConnectedFlights)
                game.CancelContract(flight.Number);
        }
    }
}
