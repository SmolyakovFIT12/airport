namespace Airport.GameViewController
{
    partial class ContractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractForm));
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeFlight = new System.Windows.Forms.Label();
            this.picTime = new System.Windows.Forms.PictureBox();
            this.tbTimeValue = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFlight.Location = new System.Drawing.Point(238, 576);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(157, 53);
            this.btnAddFlight.TabIndex = 0;
            this.btnAddFlight.Text = "Назначить рейс";
            this.btnAddFlight.UseVisualStyleBackColor = false;
            this.btnAddFlight.Click += new System.EventHandler(this.BtnAddFlight_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(416, 576);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 53);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(30, 456);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(123, 20);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Время вылета:";
            // 
            // lblTimeFlight
            // 
            this.lblTimeFlight.AutoSize = true;
            this.lblTimeFlight.BackColor = System.Drawing.Color.White;
            this.lblTimeFlight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimeFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeFlight.Location = new System.Drawing.Point(190, 447);
            this.lblTimeFlight.MinimumSize = new System.Drawing.Size(250, 40);
            this.lblTimeFlight.Name = "lblTimeFlight";
            this.lblTimeFlight.Size = new System.Drawing.Size(250, 40);
            this.lblTimeFlight.TabIndex = 3;
            // 
            // picTime
            // 
            this.picTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picTime.BackColor = System.Drawing.Color.White;
            this.picTime.Image = ((System.Drawing.Image)(resources.GetObject("picTime.Image")));
            this.picTime.Location = new System.Drawing.Point(195, 450);
            this.picTime.Name = "picTime";
            this.picTime.Size = new System.Drawing.Size(34, 34);
            this.picTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTime.TabIndex = 8;
            this.picTime.TabStop = false;
            // 
            // tbTimeValue
            // 
            this.tbTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTimeValue.Location = new System.Drawing.Point(239, 448);
            this.tbTimeValue.Mask = "00 ч  00 мин";
            this.tbTimeValue.MaximumSize = new System.Drawing.Size(200, 38);
            this.tbTimeValue.MinimumSize = new System.Drawing.Size(200, 38);
            this.tbTimeValue.Name = "tbTimeValue";
            this.tbTimeValue.ResetOnSpace = false;
            this.tbTimeValue.Size = new System.Drawing.Size(200, 19);
            this.tbTimeValue.TabIndex = 9;
            this.tbTimeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTimeValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TbTimeValue_MouseClick);
            // 
            // ContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(560, 650);
            this.Controls.Add(this.tbTimeValue);
            this.Controls.Add(this.picTime);
            this.Controls.Add(this.lblTimeFlight);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddFlight);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(560, 685);
            this.MinimumSize = new System.Drawing.Size(560, 0);
            this.Name = "ContractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ContractForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ContractForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFlight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeFlight;
        private System.Windows.Forms.PictureBox picTime;
        private System.Windows.Forms.MaskedTextBox tbTimeValue;
    }
}