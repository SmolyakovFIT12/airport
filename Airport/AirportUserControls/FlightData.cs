using Airport.GameLogicInterface;
using Airport.GameModel;
using Airport.GameViewController;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airport
{
    public partial class FlightData : UserControl
    {
        IGameLogicInteractable game;
        Flight flight;

        public FlightData(bool isPassenger, Flight flight, IGameLogicInteractable game)
        {
            InitializeComponent();

            this.game = game;
            this.flight = flight;

            BackColor = MainForm.MostlyBackColor;
            btnGet.BackColor = MainForm.MostlyBackColor;

            if (isPassenger)
            {
                lblFlightType.Text = "Пассажиры:";
                lblFlightType.Width = 109;
                lblFlightTypeValue.Location = new Point(124, 55);
            }
            else
            {
                lblFlightType.Text = "Грузоподъемность:";
                lblFlightType.Width = 175;
                lblFlightTypeValue.Location = new Point(190, 55);
            }
        }

        public string FlightName
        {
            get { return lblFlightName.Text; }
            set
            {
                lblFlightName.Text = value;
            }
        }

        public string FlightTypeValue
        {
            get { return lblFlightTypeValue.Text; }
            set
            {
                lblFlightTypeValue.Text = value;
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

        public string TypeValue
        {
            get { return lblTypeValue.Text; }
            set
            {
                lblTypeValue.Text = value;
            }
        }

        public decimal PriceValue
        {
            get { return uint.Parse(lblPriceValue.Text.Replace("$ ", "")); }
            set
            {
                lblPriceValue.Text = "$ " + value;
            }
        }

        public event EventHandler OnActionGet
        {
            add { btnGet.Click += value; }
            remove { btnGet.Click -= value; }
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            game.SignContract(flight.Number);
        }
    }
}
