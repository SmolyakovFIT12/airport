namespace Airport.AirportUserControls
{
    partial class PlaneMarket
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.lblRangeValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblDayValue = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblPlaneName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMaxValue.Location = new System.Drawing.Point(136, 52);
            this.lblMaxValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxValue.MaximumSize = new System.Drawing.Size(70, 20);
            this.lblMaxValue.MinimumSize = new System.Drawing.Size(70, 20);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(70, 20);
            this.lblMaxValue.TabIndex = 73;
            this.lblMaxValue.Text = "Value";
            this.lblMaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRangeValue
            // 
            this.lblRangeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRangeValue.AutoSize = true;
            this.lblRangeValue.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRangeValue.Location = new System.Drawing.Point(117, 76);
            this.lblRangeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRangeValue.MaximumSize = new System.Drawing.Size(60, 20);
            this.lblRangeValue.MinimumSize = new System.Drawing.Size(60, 20);
            this.lblRangeValue.Name = "lblRangeValue";
            this.lblRangeValue.Size = new System.Drawing.Size(60, 20);
            this.lblRangeValue.TabIndex = 72;
            this.lblRangeValue.Text = "Value";
            this.lblRangeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.MinimumSize = new System.Drawing.Size(65, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "Вместимость:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.MinimumSize = new System.Drawing.Size(65, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 70;
            this.label1.Text = "Дальность:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(359, 67);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(104, 23);
            this.cbType.TabIndex = 69;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPriceValue.Location = new System.Drawing.Point(391, 13);
            this.lblPriceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriceValue.MaximumSize = new System.Drawing.Size(80, 20);
            this.lblPriceValue.MinimumSize = new System.Drawing.Size(80, 20);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(80, 20);
            this.lblPriceValue.TabIndex = 66;
            this.lblPriceValue.Text = "Value";
            this.lblPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDayValue
            // 
            this.lblDayValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDayValue.AutoSize = true;
            this.lblDayValue.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDayValue.Location = new System.Drawing.Point(336, 33);
            this.lblDayValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDayValue.MaximumSize = new System.Drawing.Size(120, 20);
            this.lblDayValue.MinimumSize = new System.Drawing.Size(120, 20);
            this.lblDayValue.Name = "lblDayValue";
            this.lblDayValue.Size = new System.Drawing.Size(120, 20);
            this.lblDayValue.TabIndex = 68;
            this.lblDayValue.Text = "Value";
            this.lblDayValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblType.Location = new System.Drawing.Point(308, 71);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.MaximumSize = new System.Drawing.Size(44, 20);
            this.lblType.MinimumSize = new System.Drawing.Size(44, 20);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 20);
            this.lblType.TabIndex = 67;
            this.lblType.Text = "Тип:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(336, 13);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.MaximumSize = new System.Drawing.Size(57, 20);
            this.lblPrice.MinimumSize = new System.Drawing.Size(57, 20);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(57, 20);
            this.lblPrice.TabIndex = 65;
            this.lblPrice.Text = "Цена:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuy
            // 
            this.btnBuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuy.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBuy.Location = new System.Drawing.Point(382, 107);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(72, 30);
            this.btnBuy.TabIndex = 64;
            this.btnBuy.Text = "Купить";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.BtnBuy_Click);
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpeedValue.Location = new System.Drawing.Point(105, 115);
            this.lblSpeedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeedValue.MaximumSize = new System.Drawing.Size(60, 20);
            this.lblSpeedValue.MinimumSize = new System.Drawing.Size(60, 20);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(60, 20);
            this.lblSpeedValue.TabIndex = 63;
            this.lblSpeedValue.Text = "Value";
            this.lblSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpeed.Location = new System.Drawing.Point(13, 115);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.MinimumSize = new System.Drawing.Size(65, 20);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(77, 20);
            this.lblSpeed.TabIndex = 62;
            this.lblSpeed.Text = "Скорость:";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlaneName
            // 
            this.lblPlaneName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPlaneName.AutoSize = true;
            this.lblPlaneName.Font = new System.Drawing.Font("Comic Sans MS", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlaneName.Location = new System.Drawing.Point(8, 11);
            this.lblPlaneName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlaneName.MaximumSize = new System.Drawing.Size(200, 32);
            this.lblPlaneName.MinimumSize = new System.Drawing.Size(200, 32);
            this.lblPlaneName.Name = "lblPlaneName";
            this.lblPlaneName.Size = new System.Drawing.Size(200, 32);
            this.lblPlaneName.TabIndex = 61;
            this.lblPlaneName.Text = "PlaneName";
            this.lblPlaneName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlaneMarket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.lblMaxValue);
            this.Controls.Add(this.lblRangeValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lblPriceValue);
            this.Controls.Add(this.lblDayValue);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.lblSpeedValue);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblPlaneName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSize = new System.Drawing.Size(480, 150);
            this.MinimumSize = new System.Drawing.Size(480, 150);
            this.Name = "PlaneMarket";
            this.Size = new System.Drawing.Size(480, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.Label lblRangeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblDayValue;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label lblSpeedValue;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblPlaneName;
    }
}
