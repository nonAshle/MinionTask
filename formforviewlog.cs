using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DailyPlanner.code.codeforformforviewlog;

namespace DailyPlanner
{
    public partial class formforviewlog : Form
    {
        private string idrequest;

        public formforviewlog(string id)
        {
            InitializeComponent();
            idrequest = id;
        }

        private void formforviewlog_Load(object sender, EventArgs e)
        {
            labelforid.Text = idrequest;
            loadlog(Convert.ToInt32(idrequest), richTextBoxforlog);
        }
    }
}
