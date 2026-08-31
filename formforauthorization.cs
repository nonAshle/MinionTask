using System.Diagnostics.Eventing.Reader;
using static DailyPlanner.code.codeforauthorization;

namespace DailyPlanner
{
    public partial class formforauthorization : Form
    {
        public formforauthorization()
        {
            InitializeComponent();
        }

        private void buttonforauthorization_Click(object sender, EventArgs e)
        {
            methodforbuttonauthorization(textboxforwritelogin.Text, textboxforwritepassword.Text, this);
        }
    }
}
