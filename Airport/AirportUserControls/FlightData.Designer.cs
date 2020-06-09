namespace Airport
{
    partial class FlightData
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
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblFlight = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFlightName = new System.Windows.Forms.Label();
            this.lblFlightTypeValue = new System.Windows.Forms.Label();
            this.lblFlightType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTypeValue.AutoSize = true;
            this.lblTypeValue.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTypeValue.Location = new System.Drawing.Point(59, 112);
            this.lblTypeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeValue.MaximumSize = new System.Drawing.Size(110, 20);
            this.lblTypeValue.MinimumSize = new System.Drawing.Size(110, 20);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(110, 20);
            this.lblTypeValue.TabIndex = 57;
            this.lblTypeValue.Text = "Value";
            this.lblTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblType.Location = new System.Drawing.Point(14, 112);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.MaximumSize = new System.Drawing.Size(45, 0);
            this.lblType.MinimumSize = new System.Drawing.Size(45, 20);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(45, 20);
            this.lblType.TabIndex = 56;
            this.lblType.Text = "Тип:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGet
            // 
            this.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGet.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGet.Location = new System.Drawing.Point(274, 102);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(190, 35);
            this.btnGet.TabIndex = 55;
            this.btnGet.Text = "Взять рейс";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(269, 52);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.MaximumSize = new System.Drawing.Size(95, 0);
            this.lblPrice.MinimumSize = new System.Drawing.Size(95, 20);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(95, 38);
            this.lblPrice.TabIndex = 54;
            this.lblPrice.Text = "Цена перелета:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlight
            // 
            this.lblFlight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFlight.AutoSize = true;
            this.lblFlight.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFlight.Location = new System.Drawing.Point(15, 11);
            this.lblFlight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlight.MaximumSize = new System.Drawing.Size(88, 0);
            this.lblFlight.MinimumSize = new System.Drawing.Size(88, 20);
            this.lblFlight.Name = "lblFlight";
            this.lblFlight.Size = new System.Drawing.Size(88, 30);
            this.lblFlight.TabIndex = 53;
            this.lblFlight.Text = "Рейс:";
            this.lblFlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPriceValue.Location = new System.Drawing.Point(372, 72);
            this.lblPriceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriceValue.MaximumSize = new System.Drawing.Size(90, 20);
            this.lblPriceValue.MinimumSize = new System.Drawing.Size(90, 20);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(90, 20);
            this.lblPriceValue.TabIndex = 52;
            this.lblPriceValue.Text = "Value";
            this.lblPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPriceValue.UseWaitCursor = true;
            // 
            // lblDateValue
            // 
            this.lblDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateValue.Location = new System.Drawing.Point(73, 82);
            this.lblDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateValue.MaximumSize = new System.Drawing.Size(187, 20);
            this.lblDateValue.MinimumSize = new System.Drawing.Size(187, 20);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(187, 20);
            this.lblDateValue.TabIndex = 51;
            this.lblDateValue.Text = "Value";
            this.lblDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(15, 82);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.MaximumSize = new System.Drawing.Size(58, 0);
            this.lblDate.MinimumSize = new System.Drawing.Size(58, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(58, 20);
            this.lblDate.TabIndex = 50;
            this.lblDate.Text = "Дата:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlightName
            // 
            this.lblFlightName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFlightName.AutoSize = true;
            this.lblFlightName.Font = new System.Drawing.Font("Comic Sans MS", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFlightName.Location = new System.Drawing.Point(101, 8);
            this.lblFlightName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlightName.MaximumSize = new System.Drawing.Size(360, 32);
            this.lblFlightName.MinimumSize = new System.Drawing.Size(360, 32);
            this.lblFlightName.Name = "lblFlightName";
            this.lblFlightName.Size = new System.Drawing.Size(360, 32);
            this.lblFlightName.TabIndex = 47;
            this.lblFlightName.Text = "City1 - City2";
            this.lblFlightName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlightTypeValue
            // 
            this.lblFlightTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFlightTypeValue.AutoSize = true;
            this.lblFlightTypeValue.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFlightTypeValue.Location = new System.Drawing.Point(189, 52);
            this.lblFlightTypeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlightTypeValue.MaximumSize = new System.Drawing.Size(170, 20);
            this.lblFlightTypeValue.MinimumSize = new System.Drawing.Size(70, 20);
            this.lblFlightTypeValue.Name = "lblFlightTypeValue";
            this.lblFlightTypeValue.Size = new System.Drawing.Size(70, 20);
            this.lblFlightTypeValue.TabIndex = 49;
            this.lblFlightTypeValue.Text = "Value";
            this.lblFlightTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlightType
            // 
            this.lblFlightType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFlightType.AutoSize = true;
            this.lblFlightType.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightType.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFlightType.Location = new System.Drawing.Point(14, 52);
            this.lblFlightType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFlightType.MaximumSize = new System.Drawing.Size(175, 0);
            this.lblFlightType.MinimumSize = new System.Drawing.Size(175, 20);
            this.lblFlightType.Name = "lblFlightType";
            this.lblFlightType.Size = new System.Drawing.Size(175, 20);
            this.lblFlightType.TabIndex = 48;
            this.lblFlightType.Text = "FlightType:";
            this.lblFlightType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlightData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.lblTypeValue);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblFlight);
            this.Controls.Add(this.lblPriceValue);
            this.Controls.Add(this.lblDateValue);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblFlightName);
            this.Controls.Add(this.lblFlightTypeValue);
            this.Controls.Add(this.lblFlightType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSize = new System.Drawing.Size(480, 150);
            this.MinimumSize = new System.Drawing.Size(480, 150);
            this.Name = "FlightData";
            this.Size = new System.Drawing.Size(480, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblFlight;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFlightName;
        private System.Windows.Forms.Label lblFlightTypeValue;
        private System.Windows.Forms.Label lblFlightType;
    }
}
