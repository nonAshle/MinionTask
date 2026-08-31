namespace DailyPlanner
{
    partial class formforauthorization
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formforauthorization));
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            buttonforauthorization = new Button();
            textboxforwritepassword = new TextBox();
            label2 = new Label();
            textboxforwritelogin = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.3464088F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.16883F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.5671F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel1.Controls.Add(panel1, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.4064827F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5935173F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tableLayoutPanel1.Size = new Size(764, 484);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonforauthorization);
            panel1.Controls.Add(textboxforwritepassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textboxforwritelogin);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(248, 153);
            panel1.Name = "panel1";
            panel1.Size = new Size(235, 245);
            panel1.TabIndex = 0;
            // 
            // buttonforauthorization
            // 
            buttonforauthorization.BackColor = Color.FromArgb(255, 128, 128);
            buttonforauthorization.Location = new Point(42, 184);
            buttonforauthorization.Name = "buttonforauthorization";
            buttonforauthorization.Size = new Size(111, 40);
            buttonforauthorization.TabIndex = 2;
            buttonforauthorization.Text = "Войти";
            buttonforauthorization.UseVisualStyleBackColor = false;
            buttonforauthorization.Click += buttonforauthorization_Click;
            // 
            // textboxforwritepassword
            // 
            textboxforwritepassword.Location = new Point(3, 129);
            textboxforwritepassword.Name = "textboxforwritepassword";
            textboxforwritepassword.Size = new Size(199, 30);
            textboxforwritepassword.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 103);
            label2.Name = "label2";
            label2.Size = new Size(69, 23);
            label2.TabIndex = 2;
            label2.Text = "Пароль";
            // 
            // textboxforwritelogin
            // 
            textboxforwritelogin.Location = new Point(3, 49);
            textboxforwritelogin.Name = "textboxforwritelogin";
            textboxforwritelogin.Size = new Size(199, 30);
            textboxforwritelogin.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 23);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 0;
            label1.Text = "Имя пользователя";
            // 
            // formforauthorization
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(764, 484);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(780, 523);
            Name = "formforauthorization";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DailyPlanner";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private TextBox textboxforwritelogin;
        private TextBox textboxforwritepassword;
        private Label label2;
        private Button buttonforauthorization;
    }
}
