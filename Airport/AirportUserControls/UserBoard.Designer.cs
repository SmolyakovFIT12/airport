namespace Airport
{
    partial class UserBoard
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
            this.SuspendLayout();
            // 
            // panelAll
            // 
            this.panelAll.AutoScroll = true;
            this.panelAll.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelAll.Location = new System.Drawing.Point(0, 9);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1058, 365);
            this.panelAll.TabIndex = 3;
            // 
            // UserBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelAll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSize = new System.Drawing.Size(1060, 385);
            this.MinimumSize = new System.Drawing.Size(1060, 385);
            this.Name = "UserBoard";
            this.Size = new System.Drawing.Size(1058, 383);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAll;
    }
}
