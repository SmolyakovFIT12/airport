namespace Airport
{
    partial class UserScroll
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
            this.panelAll = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelAll
            // 
            this.panelAll.AutoScroll = true;
            this.panelAll.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelAll.Location = new System.Drawing.Point(0, 51);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(518, 320);
            this.panelAll.TabIndex = 3;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblText.Location = new System.Drawing.Point(110, 12);
            this.lblText.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblText.MinimumSize = new System.Drawing.Size(300, 36);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(300, 36);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Your Elements";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserScroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.lblText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximumSize = new System.Drawing.Size(520, 385);
            this.MinimumSize = new System.Drawing.Size(520, 385);
            this.Name = "UserScroll";
            this.Size = new System.Drawing.Size(518, 383);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Label lblText;
    }
}
