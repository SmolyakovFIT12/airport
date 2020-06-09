using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Airport.AirportUserControls;
using Airport.CustomDialogs;
using Airport.GameLogicInterface;
using Airport.GameModel;
using Airport.GameViewController;

namespace Airport
{
    [Serializable]
    public partial class PlaneData : UserControl
    {
        private IGameLogicInteractable game;
        private Plane plane;
        private List<City> cities;
        private ObservableCollection<Plane> planes;
        private PlaneDataType type;
        public PlaneData(PlaneDataType type, IGameLogicInteractable game, List<City> cities, Plane plane)
        {
            InitializeComponent();

            this.plane = plane;
            this.game = game;
            this.cities = cities;
            this.type = type;
            planes = game.GetPlanes();
            plane.DeprecationDegreeChanged += Plane_DeprecationDegreeChanged;

            BackColor = MainForm.MostlyBackColor;
            btnFly.BackColor = MainForm.MostlyBackColor;
            btnSell.BackColor = MainForm.MostlyBackColor;
            lblCityName.BackColor = MainForm.MostlyBackColor;
            switch (type)
            {
                case PlaneDataType.SelectPlane:
                    {
                        btnFly.Visible = false;
                        lblPrice.Visible = false;
                        lblPriceValue.Visible = false;
                        lblType.Visible = false;
                        lblTypeValue.Visible = false;
                        lblCityName.Visible = false;
                        lblCity.Visible = false;
                        btnSell.Visible = false;
                       
                        RangeValue = plane.Range;
                        SetMaxValue(plane.MaxSeatings, plane.Payload);
                    } break;
                case PlaneDataType.TransferPlane:
                    {
                        rbCheck.Visible = false;
                        lblPrice.Visible = false;
                        lblPriceValue.Visible = false;
                        lblType.Visible = false;
                        lblTypeValue.Visible = false;
                        btnSell.Visible = false;
                        lblRange.Visible = false;
                        lblRangeValue.Visible = false;
                        lblMax.Visible = false;
                        lblMaxValue.Visible = false;
                    } break;
                case PlaneDataType.SellPlane:
                    {
                        btnFly.Visible = false;
                        rbCheck.Visible = false;
                        lblType.Visible = false;
                        lblTypeValue.Visible = false;
                        lblCity.Visible = false;
                        lblCityName.Visible = false;
                        RangeValue = plane.Range;
                        SetMaxValue(plane.MaxSeatings, plane.Payload);
                       
                    } break;
                }
            switch (plane.Own)
            {
                case Plane.Owns.Rented:
                    lblMarketContract.Text = "Аренда:";
                    lblMarketDaysValue.Text = plane.MarketC.Days.ToString() + " д.";
                    break;
                case Plane.Owns.Bought:
                    lblMarketDaysValue.Visible = false;
                    lblMarketContract.Visible = false;
                    break;
                case Plane.Owns.Leased:
                    if (Plane.MarketC.Days > 0)
                    {
                        lblMarketContract.Text = "Лизинг:";
                        lblMarketDaysValue.Text = plane.MarketC.Days.ToString() + " д.";

                    }
                    else
                    {
                        lblMarketDaysValue.Visible = false;
                        lblMarketContract.Visible = false;
                    }
                    break;
            }
            
        }

        private void Plane_DeprecationDegreeChanged(object sender, double e)
        {
            if (lblDeprecationValue.IsHandleCreated)
            {
                lblDeprecationValue.Invoke(new Action(() => lblDeprecationValue.Text = String.Format("{0:0.000}%", e)));
            }
            
            else
            {
                lblDeprecationValue.Text = String.Format("{0:0.000}%", e);
            }

            if (lblPriceValue.IsHandleCreated)
            {
                lblPriceValue.Invoke(new Action(() => lblPriceValue.Text = "$" + (DefaultPrice * (1 - DeprecationValue * 0.01)).ToString()));
                if (this.type == PlaneDataType.RentPlane || this.type == PlaneDataType.LeasingPlane)
                {
                    lblPriceValue.Invoke(new Action(() => lblPriceValue.Text += "/д"));
                }
            }
            else
            {
                PriceValue = DefaultPrice * (1 - DeprecationValue * 0.01);
            }
        }

        public Plane Plane
        {
            get { return plane; }
        }

        public string PlaneName
        {
            get { return lblPlaneName.Text; }
            set { lblPlaneName.Text = value; }
        }

        public string CityName
        {
            get { return lblCityName.Text; }
            set { lblCityName.Text = value; }
        }

        public double SpeedValue
        {
            get { return double.Parse(lblSpeedValue.Text); }
            set { lblSpeedValue.Text = Math.Round(value, 1).ToString(); }
        }

        public double RangeValue
        {
            get { return double.Parse(lblRangeValue.Text); }
            set { lblRangeValue.Text = Math.Round(value, 1).ToString(); }
        }

        public double MaxSeatings
        {
            get
            {
                return double.Parse(lblMaxValue.Text.Split('/')[0]);
            }
        }

        public double MaxPayload
        {
            get
            {
                return double.Parse(lblMaxValue.Text.Split('/')[1]);
            }
        }

        public void SetMaxValue(double maxSeatings, double maxPayload)
        {
            lblMaxValue.Text = Math.Round(maxSeatings, 1).ToString() + "/" + Math.Round(maxPayload, 1).ToString();
        }

        public double DeprecationValue
        {
            get { return double.Parse(lblDeprecationValue.Text.Replace("%", "")); }
            set { lblDeprecationValue.Text = value.ToString() + "%"; }
        }

        public double DefaultPrice { get; set; }
        public double PriceValue
        {
            get { return double.Parse(lblPriceValue.Text.Replace("$", "").Replace("/д", "")); }
            set
            {
                if (lblPriceValue == null)
                    return;
                if (this.IsHandleCreated)
                {
                    lblPriceValue.Invoke(new Action(() => lblPriceValue.Text = "$" + value.ToString()));
                    if (this.type == PlaneDataType.RentPlane || this.type == PlaneDataType.LeasingPlane)
                    {
                        lblPriceValue.Invoke(new Action(() => lblPriceValue.Text += "/д"));
                    }
                }
                else
                {
                    lblPriceValue.Text = "$" + value.ToString();
                    if (this.type == PlaneDataType.RentPlane || this.type == PlaneDataType.LeasingPlane)
                    {
                        lblPriceValue.Text += "/д";
                    }
                }
            }
        }

        public bool Check
        {
            get { return rbCheck.Checked; }
        }

        public event EventHandler OnActionFly
        {
            add { btnFly.Click += value; }
            remove { btnFly.Click -= value; }
        }

        private void BtnFly_Click(object sender, EventArgs e)
        {
            ComboboxDialog dialog = new ComboboxDialog(cities);
            dialog.ShowDialog();
            if (dialog.SelectedCity != null)
            {
                if (CityName.Equals(dialog.SelectedCity.Name))
                    MessageBox.Show("Увы, самолёт уже там.");
                else if (plane.status != "В полёте")
                {
                    MessageBox.Show($"На перелет будет потрачено {game.RebasePlane(plane.ID, dialog.SelectedCity.ID)}$");
                    btnFly.Enabled = false;
                    CityName = "В полёте";
                    plane.status = "В полёте";
                }
                else
                {
                    MessageBox.Show("Самолёт уже в полёте.");
                }
            }
            else
            {
                if (dialog.PressCancel) return;
                MessageBox.Show("Увы, туда самолёт послать нельзя.");
            }
        }

        public event EventHandler OnActionSellBuy
        {
            add { btnSell.Click += value; }
            remove { btnSell.Click -= value; }
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            if (plane.Own == Plane.Owns.Rented || plane.Own == Plane.Owns.Leased)
            {
                MessageBox.Show("Нельзя продать арендованный самолет.");
                return;
            }
            if (plane.status == "В полёте")
            {
                MessageBox.Show("Самолет в полете.");
                return;
            }
            double currentSavings = Convert.ToDouble(lblPriceValue.Text.Replace("$", ""));
            planes.Remove(plane);
            game.SellPlane(currentSavings);
        }
    }
}
