using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DailyPlanner.code.codeforformforviewrequest;

namespace DailyPlanner
{
    public partial class formforviewrequest : Form
    {
        private int idRequest;
        private string userPrivilige;
        private string login;

        public formforviewrequest(int idrequest, string userprivilige, string Login)
        {
            InitializeComponent();
            idRequest = idrequest;
            userPrivilige = userprivilige;
            login = Login;
        }

        private void formforviewrequest_Load(object sender, EventArgs e)
        {
            if (userPrivilige == "worker by request")
            {
                buttonforsavechangeinformationaboutrequest.Visible = true;
                buttonforviewlog.Visible = true;
            }
            else
            {
                exportword.TabIndex = 0;
            }
            methodforviewdetailedinformationavoutrequest(idRequest, userPrivilige, panelforviewdatafromdatabase, labelforidrequest, labelforauthorequest, labelforcompanyapplicant, labelforserviceapplicant, labelfordepartmentapplicant, labelforfullnameapplicant, labelforlocationapplicant, labelforroomapplicant, labelforcontactphoneapplicant, labelforsubjectrequest, labelforRDPauthorPC, labelforrdateofequestsubmission, labelforlastmodifieddate, labelfordescriptionrequest, this);
        }

        private void formforviewrequest_Resize(object sender, EventArgs e)
        {
            labelforstoragenameid.Width = panelforstoragenamefieldid.ClientSize.Width - 25;

            foreach (Control c in panelforstoragenamefields.Controls)
            {
                c.Width = panelforstoragenamefields.ClientSize.Width - 25;
            }
        }

        private void formforviewrequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            buttonforsavechangeinformationaboutrequest.Visible = false;
        }

        private void buttonforsavechangeinformationaboutrequest_Click(object sender, EventArgs e)
        {
            methodforapplychangeinformationaboutrequest(login, idRequest, panelforviewdatafromdatabase.Controls["comboboxforservice"] as ComboBox, panelforviewdatafromdatabase.Controls["comboboxforstatus"] as ComboBox, labelforidrequest, this, panelforviewdatafromdatabase.Controls["textBoxfortechnicalstaffresponse"] as TextBox);
        }

        private void exportword_Click(object sender, EventArgs e)
        {
            createworddoc(userPrivilige, labelforidrequest, panelforviewdatafromdatabase.Controls["comboboxforservice"] as ComboBox, panelforviewdatafromdatabase.Controls["comboboxforstatus"] as ComboBox, labelforauthorequest, labelforcompanyapplicant, labelforserviceapplicant, labelfordepartmentapplicant, labelforlocationapplicant, labelforcontactphoneapplicant, labelforsubjectrequest, labelforRDPauthorPC, labelforrdateofequestsubmission, labelforlastmodifieddate, labelfordescriptionrequest, panelforviewdatafromdatabase.Controls["labelforrequiredservice"] as Label, panelforviewdatafromdatabase.Controls["labelforstatusrequest"] as Label, panelforviewdatafromdatabase.Controls["Labelfortechnicalstaffresponse"] as Label, panelforviewdatafromdatabase.Controls["textBoxfortechnicalstaffresponse"] as TextBox);
        }

        private void buttonforviewlog_Click(object sender, EventArgs e)
        {
            using (var formforviewlog = new formforviewlog(labelforidrequest.Text))
            {
                formforviewlog.ShowDialog(this);
            }
        }
    }
}
