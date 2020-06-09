using Airport.AirportUserControls;
using Airport.GameLogicInterface;
using Airport.GameModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Airport.GameViewController
{
    public partial class ContractForm : Form
    {
        UserScroll planesForContract;
        Contract contract;
        private IGameLogicInteractable game;
        List<City> cities;
        uint flightID;

        public bool IsSuccessful { get; private set; }

        public ContractForm(IGameLogicInteractable game, Contract contract, uint flightID)
        {
            InitializeComponent();  
            this.game = game;
            this.flightID = flightID;
            cities = game.GetCitiesInfo().Values.ToList();
            this.contract = contract;

            BackColor = MainForm.MostlyBackColor;
            btnAddFlight.BackColor = MainForm.MostlyBackColor;
            btnCancel.BackColor = MainForm.MostlyBackColor;

            planesForContract = new UserScroll();
            planesForContract.SetLocation(20, 40);
            planesForContract.Text = "Ваши самолеты";
            FillPlanes(PlaneDataType.SelectPlane, planesForContract);
            this.Controls.Add(planesForContract);
        }
        public void UpdatePlanesContract()
        {
            planesForContract.GetPanel.Controls.Clear();
            FillPlanes(PlaneDataType.SelectPlane, planesForContract);
        }

        public void UpdatePlanes()
        {
            planesForContract.GetPanel.Controls.Clear();
            FillPlanes(PlaneDataType.SelectPlane, planesForContract);
        }

        private void FillPlanes(PlaneDataType type, UserScroll userScroll)
        {
            // основные характеристики
            int startX = 10, startY = 5;
            var obsplane = game.GetPlanes();
            foreach (var plane in game.GetPlanes())
            {
                PlaneData planeData = new PlaneData(type, game, cities, plane)
                {
                    PlaneName = plane.Model.ToString(),
                    CityName = game.GetPlaneLocation(plane.ID) == null ? "-"
                    : game.GetPlaneLocation(plane.ID).Name,
                    SpeedValue = plane.Speed,
                    DeprecationValue = plane.DeprecationDegree,
                    Location = new Point(startX, startY),
                };
                startY += planeData.Height + 10;
                userScroll.GetPanel.Controls.Add(planeData);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, this.Width - 1, this.Height - 1);
        }

        private void ContractForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Release the mouse capture started by the mouse down.
            this.Capture = false;
            // Create and send a WM_NCLBUTTONDOWN message.
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCAPTION = 2;
            Message msg = Message.Create(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
            DefWndProc(ref msg);
        }

        private void BtnAddFlight_Click(object sender, EventArgs e)
        {
            try
            {
                string[] res = tbTimeValue.Text.Replace(" ", "").Split('ч');
                int hours = int.Parse(res[0] == "" ? "-1" : res[0]),
                    minutes = int.Parse(res[1].Replace("мин", "") == "" ? "-1" : res[1].Replace("мин", ""));
                if (hours < 0 || hours > 23)
                    throw new Exception("В сутках всего 24 часа!");
                if (minutes < 0 || hours > 59)
                    throw new Exception("В часе всего 60 минут!");
                bool found = false;
                foreach (PlaneData planeData in planesForContract.GetPanel.Controls)
                {
                    if (planeData.Check)
                    {
                        foreach (Flight flight in contract.ConnectedFlights)
                            if (!game.AssignPlaneToContract(planeData.Plane.ID, flight.Number))
                            {
                                MessageBox.Show("Выбранный самолёт не удовлетворяет критериям контракта");
                                return;
                            }
                        game.SetTimeForContract(flightID, new TimeSpan(hours, minutes, 0));
                        found = true;
                    }
                }
                if (!found)
                    throw new Exception("Вы не выбрали самолет/самолеты!");
                else
                {
                    Close();
                    IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TbTimeValue_MouseClick(object sender, MouseEventArgs e)
        {
            ((MaskedTextBox)sender).SelectionStart = 0;
        }
    }
}
