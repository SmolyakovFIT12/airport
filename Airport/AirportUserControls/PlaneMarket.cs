using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airport.GameLogicInterface;
using Airport.GameModel;
using Airport.GameViewController;
using Airport.Properties;

namespace Airport.AirportUserControls
{
    [Serializable]
    public partial class PlaneMarket : UserControl
    {
        private IGameLogicInteractable game;
        private Plane.Models model;

        //цена покупки сразу
        private double buyPrice;

        //цена аренды за день
        private double rentPrice;

        //цена выплаты лизинга в день (сделала в день, потому чтов месяц это слишком долго)
        private double leasingPrice;


        public PlaneMarket(IGameLogicInteractable game, Plane.Models model, int days)
        {
            InitializeComponent();
            BackColor = MainForm.MostlyBackColor;
            btnBuy.BackColor = MainForm.MostlyBackColor;
            cbType.BackColor = MainForm.MostlyBackColor;
            cbType.Items.AddRange(new object[] { "Покупка", "Аренда", "Лизинг" });
            Bitmap picture = null;
            switch (model)
            {
                case Plane.Models.TY_134:
                    {
                        picture = Resources.AirbusA330_200;
                    }
                    break;
                case Plane.Models.SuperJet123:
                    {
                        picture = Resources.Boeing747_8i;
                    }
                    break;
                case Plane.Models.KukuruznikMX150:
                    {
                        picture = Resources.McDonnelDouglasMD11F;
                    }
                    break;
            }
            this.model = model;
            this.game = game;
            PlaneName = model.ToString();
            PlaneCharacteristics chars = PlaneCharacteristicsStorage.Characteristics[model];
            SpeedValue = chars.Speed;
            RangeValue = chars.Range;
            SetMaxValue(chars.MaxSeatings, chars.Payload);
            DaysValue = days;

            PriceValue = game.GetBuyPrice(model);
            cbType.SelectedIndex = 0;

        }
        public Plane.Models Model
        {
            get { return model; }
        }

        public string PlaneName
        {
            get { return lblPlaneName.Text; }
            set { lblPlaneName.Text = value; }
        }

        public double SpeedValue
        {
            get { return double.Parse(lblSpeedValue.Text); }
            set { lblSpeedValue.Text = Math.Round(value, 0).ToString(); }
        }

        public double RangeValue
        {
            get { return double.Parse(lblRangeValue.Text); }
            set { lblRangeValue.Text = Math.Round(value, 0).ToString(); }
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

        public double PriceValue
        {
            get { return double.Parse(lblPriceValue.Text.Replace("$", "").Replace("/д", "")); }
            set
            {
                buyPrice = value;
                rentPrice = value * 0.07 / (double)DaysValue;
                leasingPrice = value * 1.5 / (double)DaysValue;

                cbType.SelectedIndex = 0;

            }
        }

        public int DaysValue
        {
            get { return int.Parse(lblDayValue.Text.Replace("(", "").Replace(" дней)", "")); }
            set { lblDayValue.Text = "(" + value + " дней)"; }
        }

        public event EventHandler OnActionSellBuy
        {
            add { btnBuy.Click += value; }
            remove { btnBuy.Click -= value; }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            //СОБЫТИЕ НАЖАТИЯ КНОПКИ ПОКУПКИ
            switch (cbType.SelectedIndex)
            {
                case 0: //PlaneDataType.BuyPlane покупка
                    {
                        game.BuyPlane(model, buyPrice);
                    }
                    break;
                case 1: //PlaneDataType.RentPlane аренда
                    {
                        game.RentPlane(model, rentPrice, DaysValue);
                    }
                    break;
                case 2: //PlaneDataType.LeasingPlane лизинг
                    {
                        game.LeasePlane(model, rentPrice, DaysValue);
                    }
                    break;
            }
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0: //PlaneDataType.BuyPlane
                    {
                        lblPriceValue.Text = "$" + Math.Round(buyPrice, 0).ToString();// priceType.Replace("/д", "");
                        lblDayValue.Visible = false;
                    }
                    break;
                case 1: //PlaneDataType.RentPlane
                    {
                        lblPriceValue.Text = "$" + Math.Round(rentPrice, 0).ToString() + "/д";
                        lblDayValue.Visible = true;
                    }
                    break;
                case 2: //PlaneDataType.LeasingPlane
                    {
                        lblPriceValue.Text = "$" + Math.Round(leasingPrice, 0).ToString() + "/д";
                        lblDayValue.Visible = true;
                    }
                    break;
            }
        }
    }
}
