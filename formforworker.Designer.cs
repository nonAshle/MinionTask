namespace DailyPlanner
{
    partial class formforworker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formforworker));
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            labelforheadertext = new Label();
            panel2 = new Panel();
            checkBoxforincludesdatefromdatapicker = new CheckBox();
            DateTimePickerforsortingrequests = new DateTimePicker();
            panel3 = new Panel();
            radioButtonforwaitstatus = new RadioButton();
            radioButtonforappliedstatus = new RadioButton();
            radioButtonfordeniedstatus = new RadioButton();
            radioButtonforstatuscomplete = new RadioButton();
            checkBoxforsortingrequestbymyselfcreate = new CheckBox();
            panel4 = new Panel();
            Buttonforstepbacktoauthorization = new Button();
            panel5 = new Panel();
            Buttonforcreatenewrequets = new Button();
            flowLayoutPanelforviewrequets = new FlowLayoutPanel();
            panel6 = new Panel();
            buttonforrefreshlistrequest = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.7378979F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.2621F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 129F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel4, 2, 2);
            tableLayoutPanel1.Controls.Add(panel5, 2, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanelforviewrequets, 1, 1);
            tableLayoutPanel1.Controls.Add(panel6, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.7440758F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.25592F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel1.Size = new Size(1134, 570);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelforheadertext);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(261, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(740, 65);
            panel1.TabIndex = 0;
            // 
            // labelforheadertext
            // 
            labelforheadertext.AutoSize = true;
            labelforheadertext.Location = new Point(292, 23);
            labelforheadertext.Name = "labelforheadertext";
            labelforheadertext.Size = new Size(190, 23);
            labelforheadertext.TabIndex = 0;
            labelforheadertext.Text = "Заявки созданные вами";
            // 
            // panel2
            // 
            panel2.Controls.Add(checkBoxforincludesdatefromdatapicker);
            panel2.Controls.Add(DateTimePickerforsortingrequests);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 65);
            panel2.TabIndex = 1;
            // 
            // checkBoxforincludesdatefromdatapicker
            // 
            checkBoxforincludesdatefromdatapicker.AutoSize = true;
            checkBoxforincludesdatefromdatapicker.Location = new Point(15, 27);
            checkBoxforincludesdatefromdatapicker.Name = "checkBoxforincludesdatefromdatapicker";
            checkBoxforincludesdatefromdatapicker.Size = new Size(15, 14);
            checkBoxforincludesdatefromdatapicker.TabIndex = 0;
            checkBoxforincludesdatefromdatapicker.UseVisualStyleBackColor = true;
            checkBoxforincludesdatefromdatapicker.CheckedChanged += checkBoxforincludesdatefromdatapicker_CheckedChanged;
            // 
            // DateTimePickerforsortingrequests
            // 
            DateTimePickerforsortingrequests.Location = new Point(36, 18);
            DateTimePickerforsortingrequests.Name = "DateTimePickerforsortingrequests";
            DateTimePickerforsortingrequests.Size = new Size(211, 30);
            DateTimePickerforsortingrequests.TabIndex = 0;
            DateTimePickerforsortingrequests.TabStop = false;
            DateTimePickerforsortingrequests.ValueChanged += DateTimePickerforsortingrequests_ValueChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(radioButtonforwaitstatus);
            panel3.Controls.Add(radioButtonforappliedstatus);
            panel3.Controls.Add(radioButtonfordeniedstatus);
            panel3.Controls.Add(radioButtonforstatuscomplete);
            panel3.Controls.Add(checkBoxforsortingrequestbymyselfcreate);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 74);
            panel3.Name = "panel3";
            panel3.Size = new Size(252, 439);
            panel3.TabIndex = 2;
            // 
            // radioButtonforwaitstatus
            // 
            radioButtonforwaitstatus.AutoSize = true;
            radioButtonforwaitstatus.Location = new Point(9, 142);
            radioButtonforwaitstatus.Name = "radioButtonforwaitstatus";
            radioButtonforwaitstatus.Size = new Size(124, 27);
            radioButtonforwaitstatus.TabIndex = 4;
            radioButtonforwaitstatus.Text = "Ожидающие";
            radioButtonforwaitstatus.UseVisualStyleBackColor = true;
            radioButtonforwaitstatus.CheckedChanged += radioButtonforwaitstatus_CheckedChanged;
            // 
            // radioButtonforappliedstatus
            // 
            radioButtonforappliedstatus.AutoSize = true;
            radioButtonforappliedstatus.Location = new Point(9, 100);
            radioButtonforappliedstatus.Name = "radioButtonforappliedstatus";
            radioButtonforappliedstatus.Size = new Size(95, 27);
            radioButtonforappliedstatus.TabIndex = 3;
            radioButtonforappliedstatus.Text = "Принята";
            radioButtonforappliedstatus.UseVisualStyleBackColor = true;
            radioButtonforappliedstatus.CheckedChanged += radioButtonforappliedstatus_CheckedChanged;
            // 
            // radioButtonfordeniedstatus
            // 
            radioButtonfordeniedstatus.AutoSize = true;
            radioButtonfordeniedstatus.Location = new Point(9, 58);
            radioButtonfordeniedstatus.Name = "radioButtonfordeniedstatus";
            radioButtonfordeniedstatus.Size = new Size(115, 27);
            radioButtonfordeniedstatus.TabIndex = 2;
            radioButtonfordeniedstatus.Text = "Отклонены";
            radioButtonfordeniedstatus.UseVisualStyleBackColor = true;
            radioButtonfordeniedstatus.CheckedChanged += radioButtonfordeniedstatus_CheckedChanged;
            // 
            // radioButtonforstatuscomplete
            // 
            radioButtonforstatuscomplete.AutoSize = true;
            radioButtonforstatuscomplete.Location = new Point(9, 14);
            radioButtonforstatuscomplete.Name = "radioButtonforstatuscomplete";
            radioButtonforstatuscomplete.Size = new Size(119, 27);
            radioButtonforstatuscomplete.TabIndex = 1;
            radioButtonforstatuscomplete.TabStop = true;
            radioButtonforstatuscomplete.Text = "Выполнены";
            radioButtonforstatuscomplete.UseVisualStyleBackColor = true;
            radioButtonforstatuscomplete.CheckedChanged += radioButtonforstatuscomplete_CheckedChanged;
            // 
            // checkBoxforsortingrequestbymyselfcreate
            // 
            checkBoxforsortingrequestbymyselfcreate.AutoSize = true;
            checkBoxforsortingrequestbymyselfcreate.Location = new Point(9, 382);
            checkBoxforsortingrequestbymyselfcreate.Name = "checkBoxforsortingrequestbymyselfcreate";
            checkBoxforsortingrequestbymyselfcreate.Size = new Size(154, 27);
            checkBoxforsortingrequestbymyselfcreate.TabIndex = 2;
            checkBoxforsortingrequestbymyselfcreate.Text = "Созданные вами";
            checkBoxforsortingrequestbymyselfcreate.UseVisualStyleBackColor = true;
            checkBoxforsortingrequestbymyselfcreate.Visible = false;
            checkBoxforsortingrequestbymyselfcreate.CheckedChanged += checkBoxforsortingrequestbymyselfcreate_CheckedChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(Buttonforstepbacktoauthorization);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(1007, 519);
            panel4.Name = "panel4";
            panel4.Size = new Size(124, 48);
            panel4.TabIndex = 3;
            // 
            // Buttonforstepbacktoauthorization
            // 
            Buttonforstepbacktoauthorization.BackColor = Color.Firebrick;
            Buttonforstepbacktoauthorization.ForeColor = SystemColors.ControlLightLight;
            Buttonforstepbacktoauthorization.Location = new Point(15, 7);
            Buttonforstepbacktoauthorization.Name = "Buttonforstepbacktoauthorization";
            Buttonforstepbacktoauthorization.Size = new Size(91, 32);
            Buttonforstepbacktoauthorization.TabIndex = 5;
            Buttonforstepbacktoauthorization.Text = "Выход";
            Buttonforstepbacktoauthorization.UseVisualStyleBackColor = false;
            Buttonforstepbacktoauthorization.Click += Buttonforstepbacktoauthorization_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(Buttonforcreatenewrequets);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(1007, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(124, 65);
            panel5.TabIndex = 4;
            // 
            // Buttonforcreatenewrequets
            // 
            Buttonforcreatenewrequets.BackColor = Color.FromArgb(0, 123, 255);
            Buttonforcreatenewrequets.Location = new Point(0, 18);
            Buttonforcreatenewrequets.Name = "Buttonforcreatenewrequets";
            Buttonforcreatenewrequets.Size = new Size(124, 30);
            Buttonforcreatenewrequets.TabIndex = 4;
            Buttonforcreatenewrequets.Text = "Новая заявка";
            Buttonforcreatenewrequets.UseVisualStyleBackColor = false;
            Buttonforcreatenewrequets.Click += Buttonforcreatenewrequets_Click;
            // 
            // flowLayoutPanelforviewrequets
            // 
            flowLayoutPanelforviewrequets.AutoScroll = true;
            flowLayoutPanelforviewrequets.Dock = DockStyle.Fill;
            flowLayoutPanelforviewrequets.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelforviewrequets.Location = new Point(261, 74);
            flowLayoutPanelforviewrequets.Name = "flowLayoutPanelforviewrequets";
            flowLayoutPanelforviewrequets.Size = new Size(740, 439);
            flowLayoutPanelforviewrequets.TabIndex = 7;
            flowLayoutPanelforviewrequets.WrapContents = false;
            flowLayoutPanelforviewrequets.Resize += flowLayoutPanelforviewrequets_Resize;
            // 
            // panel6
            // 
            panel6.Controls.Add(buttonforrefreshlistrequest);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(261, 519);
            panel6.Name = "panel6";
            panel6.Size = new Size(740, 48);
            panel6.TabIndex = 8;
            // 
            // buttonforrefreshlistrequest
            // 
            buttonforrefreshlistrequest.BackColor = Color.FromArgb(215, 230, 215);
            buttonforrefreshlistrequest.Location = new Point(276, 8);
            buttonforrefreshlistrequest.Name = "buttonforrefreshlistrequest";
            buttonforrefreshlistrequest.Size = new Size(206, 31);
            buttonforrefreshlistrequest.TabIndex = 3;
            buttonforrefreshlistrequest.Text = "Обновить список заявок";
            buttonforrefreshlistrequest.UseVisualStyleBackColor = false;
            buttonforrefreshlistrequest.Click += buttonforrefreshlistrequest_Click;
            // 
            // formforworker
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1134, 570);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1150, 609);
            Name = "formforworker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DailyPlanner";
            FormClosing += formforworker_FormClosing;
            FormClosed += formforworker_FormClosed;
            Load += formforworker_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label labelforheadertext;
        private Panel panel2;
        private DateTimePicker DateTimePickerforsortingrequests;
        private Panel panel3;
        private Panel panel4;
        private Button Buttonforstepbacktoauthorization;
        private Panel panel5;
        private Button Buttonforcreatenewrequets;
        private FlowLayoutPanel flowLayoutPanelforviewrequets;
        private CheckBox checkBoxforincludesdatefromdatapicker;
        private Panel panel6;
        private Button buttonforrefreshlistrequest;
        private CheckBox checkBoxforsortingrequestbymyselfcreate;
        private RadioButton radioButtonforstatuscomplete;
        private RadioButton radioButtonfordeniedstatus;
        private RadioButton radioButtonforappliedstatus;
        private RadioButton radioButtonforwaitstatus;
    }
}