namespace Airport.GameViewController
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAirline = new System.Windows.Forms.Button();
            this.btnBoard = new System.Windows.Forms.Button();
            this.btnPlanesMarket = new System.Windows.Forms.Button();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblBalanceValue = new System.Windows.Forms.Label();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnUpThree = new System.Windows.Forms.Button();
            this.btnUpTwo = new System.Windows.Forms.Button();
            this.btnUpOne = new System.Windows.Forms.Button();
            this.lblFuelValue = new System.Windows.Forms.Label();
            this.lblFuel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.myFormStyle1 = new Airport.MyFormStyle(this.components);
            this.SuspendLayout();
            // 
            // btnAirline
            // 
            this.btnAirline.FlatAppearance.BorderSize = 0;
            this.btnAirline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAirline.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAirline.Location = new System.Drawing.Point(382, 16);
            this.btnAirline.Margin = new System.Windows.Forms.Padding(0);
            this.btnAirline.Name = "btnAirline";
            this.btnAirline.Size = new System.Drawing.Size(101, 45);
            this.btnAirline.TabIndex = 4;
            this.btnAirline.Text = "Состояние активов";
            this.btnAirline.UseVisualStyleBackColor = true;
            this.btnAirline.Click += new System.EventHandler(this.BtnAirline_Click);
            // 
            // btnBoard
            // 
            this.btnBoard.FlatAppearance.BorderSize = 0;
            this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoard.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBoard.Location = new System.Drawing.Point(495, 16);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(101, 45);
            this.btnBoard.TabIndex = 2;
            this.btnBoard.Text = "Контракты";
            this.btnBoard.UseVisualStyleBackColor = true;
            this.btnBoard.Click += new System.EventHandler(this.BtnBoard_Click);
            // 
            // btnPlanesMarket
            // 
            this.btnPlanesMarket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlanesMarket.FlatAppearance.BorderSize = 0;
            this.btnPlanesMarket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanesMarket.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlanesMarket.Location = new System.Drawing.Point(612, 16);
            this.btnPlanesMarket.Name = "btnPlanesMarket";
            this.btnPlanesMarket.Size = new System.Drawing.Size(88, 45);
            this.btnPlanesMarket.TabIndex = 3;
            this.btnPlanesMarket.Text = "Рынок самолетов";
            this.btnPlanesMarket.UseVisualStyleBackColor = true;
            this.btnPlanesMarket.Click += new System.EventHandler(this.BtnPlanesMarket_Click);
            // 
            // lblDateValue
            // 
            this.lblDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.BackColor = System.Drawing.Color.White;
            this.lblDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateValue.Location = new System.Drawing.Point(908, 4);
            this.lblDateValue.MinimumSize = new System.Drawing.Size(11, 11);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(31, 15);
            this.lblDateValue.TabIndex = 7;
            this.lblDateValue.Text = "date";
            this.lblDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalanceValue
            // 
            this.lblBalanceValue.AutoSize = true;
            this.lblBalanceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBalanceValue.Location = new System.Drawing.Point(922, 44);
            this.lblBalanceValue.MaximumSize = new System.Drawing.Size(170, 0);
            this.lblBalanceValue.MinimumSize = new System.Drawing.Size(170, 0);
            this.lblBalanceValue.Name = "lblBalanceValue";
            this.lblBalanceValue.Size = new System.Drawing.Size(170, 29);
            this.lblBalanceValue.TabIndex = 9;
            this.lblBalanceValue.Text = "Value";
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.AutoSize = true;
            this.lblTimeValue.BackColor = System.Drawing.Color.White;
            this.lblTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeValue.Location = new System.Drawing.Point(987, 19);
            this.lblTimeValue.MaximumSize = new System.Drawing.Size(72, 0);
            this.lblTimeValue.MinimumSize = new System.Drawing.Size(72, 0);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(72, 15);
            this.lblTimeValue.TabIndex = 11;
            this.lblTimeValue.Text = "Value";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(924, 19);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(54, 15);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "Время:";
            // 
            // btnUpThree
            // 
            this.btnUpThree.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpThree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpThree.Location = new System.Drawing.Point(160, 45);
            this.btnUpThree.Name = "btnUpThree";
            this.btnUpThree.Size = new System.Drawing.Size(57, 33);
            this.btnUpThree.TabIndex = 14;
            this.btnUpThree.Text = "х100";
            this.btnUpThree.UseVisualStyleBackColor = false;
            this.btnUpThree.Click += new System.EventHandler(this.BtnUpThree_Click);
            // 
            // btnUpTwo
            // 
            this.btnUpTwo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpTwo.Location = new System.Drawing.Point(94, 44);
            this.btnUpTwo.Name = "btnUpTwo";
            this.btnUpTwo.Size = new System.Drawing.Size(40, 33);
            this.btnUpTwo.TabIndex = 13;
            this.btnUpTwo.Text = "х50";
            this.btnUpTwo.UseVisualStyleBackColor = false;
            this.btnUpTwo.Click += new System.EventHandler(this.BtnUpTwo_Click);
            // 
            // btnUpOne
            // 
            this.btnUpOne.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpOne.Enabled = false;
            this.btnUpOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpOne.Location = new System.Drawing.Point(28, 44);
            this.btnUpOne.Name = "btnUpOne";
            this.btnUpOne.Size = new System.Drawing.Size(38, 33);
            this.btnUpOne.TabIndex = 12;
            this.btnUpOne.Text = "х1";
            this.btnUpOne.UseVisualStyleBackColor = false;
            this.btnUpOne.Click += new System.EventHandler(this.BtnUpOne_Click);
            // 
            // lblFuelValue
            // 
            this.lblFuelValue.AutoSize = true;
            this.lblFuelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFuelValue.Location = new System.Drawing.Point(923, 73);
            this.lblFuelValue.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblFuelValue.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblFuelValue.Name = "lblFuelValue";
            this.lblFuelValue.Size = new System.Drawing.Size(100, 29);
            this.lblFuelValue.TabIndex = 16;
            this.lblFuelValue.Text = "Value";
            // 
            // lblFuel
            // 
            this.lblFuel.AutoSize = true;
            this.lblFuel.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFuel.Location = new System.Drawing.Point(765, 77);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(146, 26);
            this.lblFuel.TabIndex = 15;
            this.lblFuel.Text = "Цена топлива:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "скорость течения времени:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(785, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ваш баланс:";
            // 
            // myFormStyle1
            // 
            this.myFormStyle1.AllowDoubleClick = true;
            this.myFormStyle1.AllowDropForMaximize = true;
            this.myFormStyle1.AllowUserResize = false;
            this.myFormStyle1.BackColor = System.Drawing.Color.White;
            this.myFormStyle1.ContextMenuForm = null;
            this.myFormStyle1.ControlBoxButtonsWidth = 20;
            this.myFormStyle1.EnableControlBoxIconsLight = false;
            this.myFormStyle1.EnableControlBoxMouseLight = false;
            this.myFormStyle1.Form = this;
            this.myFormStyle1.FormStyle = Airport.MyFormStyle.fStyle.SimpleDark;
            this.myFormStyle1.HeaderColor = System.Drawing.Color.DimGray;
            this.myFormStyle1.HeaderColorAdditional = System.Drawing.Color.White;
            this.myFormStyle1.HeaderColorGradientEnable = false;
            this.myFormStyle1.HeaderColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.myFormStyle1.HeaderHeight = 38;
            this.myFormStyle1.HeaderImage = null;
            this.myFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.myFormStyle1.HeaderTextFont = new System.Drawing.Font("Segoe UI", 9.75F);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1084, 511);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFuelValue);
            this.Controls.Add(this.lblFuel);
            this.Controls.Add(this.btnUpThree);
            this.Controls.Add(this.btnUpTwo);
            this.Controls.Add(this.btnUpOne);
            this.Controls.Add(this.lblTimeValue);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDateValue);
            this.Controls.Add(this.lblBalanceValue);
            this.Controls.Add(this.btnPlanesMarket);
            this.Controls.Add(this.btnBoard);
            this.Controls.Add(this.btnAirline);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 550);
            this.MinimumSize = new System.Drawing.Size(1100, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Симулятор аэропорта";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAirline;
        private System.Windows.Forms.Button btnBoard;
        private System.Windows.Forms.Button btnPlanesMarket;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblTimeValue;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnUpOne;
        private System.Windows.Forms.Button btnUpTwo;
        private System.Windows.Forms.Button btnUpThree;
        private System.Windows.Forms.Label lblFuelValue;
        private System.Windows.Forms.Label lblFuel;
        public System.Windows.Forms.Label lblBalanceValue;
        private MyFormStyle myFormStyle1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}