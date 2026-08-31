using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DailyPlanner.code.codeforformforcreaterequest;

namespace DailyPlanner
{
    public partial class formforcreaterequest : Form
    {
        private string Login;
        private string userPrivilige;


        public formforcreaterequest(string login, string userprivilige)
        {
            InitializeComponent();
            Login = login;
            userPrivilige = userprivilige;
        }

        private void formforcreaterequest_Resize(object sender, EventArgs e)
        {
            foreach (Control c in panelfornamefields.Controls)
            {
                c.Width = panelfornamefields.ClientSize.Width - 25;
            }
        }

        private void buttonforinsertintodatabasenewrequest_Click(object sender, EventArgs e)
        {
            if (addnewrequest(Login, userPrivilige, comboBoxforobjectrequest, comboBoxforrequiredservice, textBoxfordescription))
            {
                this.Close();
            }
        }

        private void formforcreaterequest_Load(object sender, EventArgs e)
        {
            loaddataforlistquipmentworkerfromdatabase(Login, userPrivilige, comboBoxforobjectrequest, this);
        }

        private void comboBoxforobjectrequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddataforrequiredservice(userPrivilige, comboBoxforrequiredservice, comboBoxforobjectrequest);
        }
    }
}
