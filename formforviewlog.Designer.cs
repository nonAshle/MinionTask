namespace DailyPlanner
{
    partial class formforviewlog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formforviewlog));
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            labelforid = new Label();
            label1 = new Label();
            panel2 = new Panel();
            richTextBoxforlog = new RichTextBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 92.82561F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.1743927F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.898305F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.10169F));
            tableLayoutPanel1.Size = new Size(906, 472);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelforid);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(835, 36);
            panel1.TabIndex = 0;
            // 
            // labelforid
            // 
            labelforid.AutoSize = true;
            labelforid.Location = new Point(193, 6);
            labelforid.Name = "labelforid";
            labelforid.Size = new Size(56, 23);
            labelforid.TabIndex = 1;
            labelforid.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(195, 23);
            label1.TabIndex = 0;
            label1.Text = "Идентификатор заявки: ";
            // 
            // panel2
            // 
            panel2.Controls.Add(richTextBoxforlog);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(835, 424);
            panel2.TabIndex = 1;
            // 
            // richTextBoxforlog
            // 
            richTextBoxforlog.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxforlog.Location = new Point(3, 3);
            richTextBoxforlog.Name = "richTextBoxforlog";
            richTextBoxforlog.ReadOnly = true;
            richTextBoxforlog.Size = new Size(829, 412);
            richTextBoxforlog.TabIndex = 0;
            richTextBoxforlog.Text = "";
            // 
            // formforviewlog
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(906, 472);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Comic Sans MS", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formforviewlog";
            Text = "Daily Planner";
            Load += formforviewlog_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label labelforid;
        private RichTextBox richTextBoxforlog;
    }
}