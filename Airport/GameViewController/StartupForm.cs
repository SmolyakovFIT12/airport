using Airport.GameLogic;
using Airport.GameLogicInterface;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Airport.GameViewController
{
    public partial class StartupForm : Form
    {
        MainForm newForm;
        private IGameLogicInteractable game;
        readonly Color back = Color.FromArgb(154, 251, 247);

        public StartupForm()
        {
            InitializeComponent();

            BackColor = back;
            btnNewGame.BackColor = back;
            btnPrevGame.BackColor = back;
            btnExit.BackColor = back;

            game = new Game();
            game.Initialize(10000000, DateTime.Now);
            this.Hide();
            game.Start();
            newForm = new MainForm(game);
            newForm.ShowDialog(); 
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            game.Start();
            newForm = new MainForm(game);
            newForm.ShowDialog();
        }

        private void BtnPrevGame_Click(object sender, EventArgs e)
        {
            if (File.Exists("LastGame.game"))
            {
                using (FileStream stream = File.Open("LastGame.game", FileMode.OpenOrCreate))
                    game.LoadGame(stream);
                Hide();
                newForm = new MainForm(game);
                game.Start();
                newForm.ShowDialog();
            }
            else MessageBox.Show("К сожалению, предыдущие сохранения не найдены");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, this.Width - 1, this.Height - 1);
        }

        private void StartupForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Release the mouse capture started by the mouse down.
            this.Capture = false;
            // Create and send a WM_NCLBUTTONDOWN message.
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCAPTION = 2;
            Message msg = Message.Create(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(HTCAPTION), IntPtr.Zero);
            this.DefWndProc(ref msg);
        }
    }
}
