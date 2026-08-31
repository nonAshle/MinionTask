namespace DailyPlanner
{
    partial class formforcreaterequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formforcreaterequest));
            tableLayoutPanel1 = new TableLayoutPanel();
            panelforpalceguiobjectinwhichfillinformationaboutrequest = new Panel();
            textBoxfordescription = new TextBox();
            comboBoxforrequiredservice = new ComboBox();
            comboBoxforobjectrequest = new ComboBox();
            label1 = new Label();
            panel2 = new Panel();
            buttonforinsertintodatabasenewrequest = new Button();
            panelfornamefields = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panelforpalceguiobjectinwhichfillinformationaboutrequest.SuspendLayout();
            panel2.SuspendLayout();
            panelfornamefields.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.9902916F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.00971F));
            tableLayoutPanel1.Controls.Add(panelforpalceguiobjectinwhichfillinformationaboutrequest, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panelfornamefields, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 84.6702347F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.3297682F));
            tableLayoutPanel1.Size = new Size(1030, 561);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelforpalceguiobjectinwhichfillinformationaboutrequest
            // 
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Controls.Add(textBoxfordescription);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Controls.Add(comboBoxforrequiredservice);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Controls.Add(comboBoxforobjectrequest);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Controls.Add(label1);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Dock = DockStyle.Fill;
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Location = new Point(178, 3);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Name = "panelforpalceguiobjectinwhichfillinformationaboutrequest";
            panelforpalceguiobjectinwhichfillinformationaboutrequest.Size = new Size(849, 469);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.TabIndex = 0;
            // 
            // textBoxfordescription
            // 
            textBoxfordescription.Location = new Point(3, 220);
            textBoxfordescription.MaxLength = 300;
            textBoxfordescription.Multiline = true;
            textBoxfordescription.Name = "textBoxfordescription";
            textBoxfordescription.ScrollBars = ScrollBars.Vertical;
            textBoxfordescription.Size = new Size(837, 230);
            textBoxfordescription.TabIndex = 2;
            // 
            // comboBoxforrequiredservice
            // 
            comboBoxforrequiredservice.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxforrequiredservice.Location = new Point(3, 163);
            comboBoxforrequiredservice.Name = "comboBoxforrequiredservice";
            comboBoxforrequiredservice.Size = new Size(837, 31);
            comboBoxforrequiredservice.TabIndex = 1;
            // 
            // comboBoxforobjectrequest
            // 
            comboBoxforobjectrequest.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxforobjectrequest.Location = new Point(3, 105);
            comboBoxforobjectrequest.Name = "comboBoxforobjectrequest";
            comboBoxforobjectrequest.Size = new Size(837, 31);
            comboBoxforobjectrequest.TabIndex = 0;
            comboBoxforobjectrequest.SelectedIndexChanged += comboBoxforobjectrequest_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 20F);
            label1.Location = new Point(290, 20);
            label1.Name = "label1";
            label1.Size = new Size(230, 38);
            label1.TabIndex = 0;
            label1.Text = "Создание заявки";
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonforinsertintodatabasenewrequest);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(178, 478);
            panel2.Name = "panel2";
            panel2.Size = new Size(849, 80);
            panel2.TabIndex = 1;
            // 
            // buttonforinsertintodatabasenewrequest
            // 
            buttonforinsertintodatabasenewrequest.BackColor = Color.FromArgb(255, 128, 128);
            buttonforinsertintodatabasenewrequest.Location = new Point(702, 17);
            buttonforinsertintodatabasenewrequest.Name = "buttonforinsertintodatabasenewrequest";
            buttonforinsertintodatabasenewrequest.Size = new Size(138, 42);
            buttonforinsertintodatabasenewrequest.TabIndex = 3;
            buttonforinsertintodatabasenewrequest.Text = "Создать заявку";
            buttonforinsertintodatabasenewrequest.UseVisualStyleBackColor = false;
            buttonforinsertintodatabasenewrequest.Click += buttonforinsertintodatabasenewrequest_Click;
            // 
            // panelfornamefields
            // 
            panelfornamefields.Controls.Add(label4);
            panelfornamefields.Controls.Add(label3);
            panelfornamefields.Controls.Add(label2);
            panelfornamefields.Dock = DockStyle.Fill;
            panelfornamefields.Location = new Point(3, 3);
            panelfornamefields.Name = "panelfornamefields";
            panelfornamefields.Size = new Size(169, 469);
            panelfornamefields.TabIndex = 2;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(0, 220);
            label4.Name = "label4";
            label4.Size = new Size(169, 28);
            label4.TabIndex = 2;
            label4.Text = "Описание";
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(3, 163);
            label3.Name = "label3";
            label3.Size = new Size(166, 31);
            label3.TabIndex = 1;
            label3.Text = "Требуемая работа";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(3, 105);
            label2.Name = "label2";
            label2.Size = new Size(166, 28);
            label2.TabIndex = 0;
            label2.Text = "Обьект заявки";
            // 
            // formforcreaterequest
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1030, 561);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Comic Sans MS", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1046, 600);
            Name = "formforcreaterequest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DailyPlanner";
            Load += formforcreaterequest_Load;
            Resize += formforcreaterequest_Resize;
            tableLayoutPanel1.ResumeLayout(false);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.ResumeLayout(false);
            panelforpalceguiobjectinwhichfillinformationaboutrequest.PerformLayout();
            panel2.ResumeLayout(false);
            panelfornamefields.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelforpalceguiobjectinwhichfillinformationaboutrequest;
        private Panel panel2;
        private Panel panelfornamefields;
        private Label label1;
        private Button buttonforinsertintodatabasenewrequest;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxforobjectrequest;
        private ComboBox comboBoxforrequiredservice;
        private Label label4;
        private TextBox textBoxfordescription;
    }
}