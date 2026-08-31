using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DailyPlanner.code.codeformforworker;

namespace DailyPlanner
{
    public partial class formforworker : Form
    {
        private string login;
        private string userpriviligies;
        bool flagforclosingprogramm;

        public formforworker(string grablogin, string grabgroupprivilege)
        {
            InitializeComponent();
            login = grablogin;
            userpriviligies = grabgroupprivilege;
        }

        private void formforworker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены в том, что вы хотите закрыть приложение?", "Система", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void formforworker_FormClosed(object sender, FormClosedEventArgs e)
        {
            labelforheadertext.Text = "Заявки созданные вами";
            checkBoxforsortingrequestbymyselfcreate.Visible = false;
            if (flagforclosingprogramm == true)
            {
                Application.Exit();
            }
        }

        private void flowLayoutPanelforviewrequets_Resize(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanelforviewrequets.Controls)
            {
                c.Width = flowLayoutPanelforviewrequets.ClientSize.Width - 25;
            }
        }

        private void buttonforrefreshlistrequest_Click(object sender, EventArgs e)
        {
            if (checkBoxforsortingrequestbymyselfcreate.Checked)
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                    }
                }
            }
            else
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                    }
                }
            }
        }

        private void formforworker_Load(object sender, EventArgs e)
        {
            flagforclosingprogramm = true;
            if (userpriviligies == "worker by request")
            {
                labelforheadertext.Text = "Заявки";
                checkBoxforsortingrequestbymyselfcreate.Visible = true;
            }
            refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
        }

        private void radioButtonforstatuscomplete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonforstatuscomplete.Checked)
            {
                if (checkBoxforsortingrequestbymyselfcreate.Checked)
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                        }

                        else
                        {
                            methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                        }

                        else
                        {
                            methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                        }
                    }
                }
                else
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                        }

                        else
                        {
                            methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                        }

                        else
                        {
                            refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                        }
                    }
                }
            }
        }

        private void radioButtonfordeniedstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonfordeniedstatus.Checked)
            {
                if (checkBoxforsortingrequestbymyselfcreate.Checked)
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                        }

                        else
                        {
                            methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                        }

                        else
                        {
                            methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                        }
                    }
                }
                else
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                        }

                        else
                        {
                            methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                        }

                        else
                        {
                            refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                        }
                    }
                }
            }
        }            

        private void radioButtonforappliedstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonforappliedstatus.Checked)
            {
                if (checkBoxforsortingrequestbymyselfcreate.Checked)
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                        }

                        else
                        {
                            methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                        }

                        else
                        {
                            methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                        }
                    }
                }
                else
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                        }

                        else
                        {
                            methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                        }

                        else
                        {
                            refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                        }
                    }
                }
            }
        }

        private void radioButtonforwaitstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonforwaitstatus.Checked)
            {
                if (checkBoxforsortingrequestbymyselfcreate.Checked)
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                        }

                        else
                        {
                            methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                        }

                        else
                        {
                            methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                        }
                    }
                }
                else
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                        }

                        else
                        {
                            methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                        }

                        else
                        {
                            refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                        }
                    }
                }
            }
        }

        private void checkBoxforsortingrequestbymyselfcreate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxforsortingrequestbymyselfcreate.Checked)
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                    }
                }
            }
            else
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                    }
                }
            }
        }

        private void checkBoxforincludesdatefromdatapicker_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxforsortingrequestbymyselfcreate.Checked)
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                    }
                }
            }
            else
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                    }
                }
            }
        }

        private void DateTimePickerforsortingrequests_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxforsortingrequestbymyselfcreate.Checked)
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                    }
                }
            }
            else
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                    }
                }
            }
        }

        private void Buttonforstepbacktoauthorization_Click(object sender, EventArgs e)
        {
            flagforclosingprogramm = false;
            this.Close();
        }

        internal void methodforrefreshfromcs()
        {
            if (checkBoxforsortingrequestbymyselfcreate.Checked)
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                    }
                }
            }
            else
            {
                if (checkBoxforincludesdatefromdatapicker.Checked)
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                    }
                    else
                    {
                        methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                    }
                }
                else
                {
                    if (radioButtonforstatuscomplete.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                    }
                    else if (radioButtonfordeniedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                    }
                    else if (radioButtonforappliedstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                    }
                    else if (radioButtonforwaitstatus.Checked)
                    {
                        methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                    }
                    else
                    {
                        refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                    }
                }
            }
        }

        private void Buttonforcreatenewrequets_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены в том, что вы хотите создать новую заявку?", "Система", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var formfocreaterequest = new formforcreaterequest(login, userpriviligies))
                {
                    formfocreaterequest.ShowDialog(this);
                }

                if (checkBoxforsortingrequestbymyselfcreate.Checked)
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                        }
                        else if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                        }
                        else if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                        }
                        else if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingrequestbycreatemyselfanddateandstatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                        }
                        else
                        {
                            methodforsortingrequestbycreatemyselfanddate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                        }
                        else if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                        }
                        else if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                        }
                        else if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingloadingbyselfandbystatus(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                        }
                        else
                        {
                            methodforsortingloadingbyself(login, userpriviligies, flowLayoutPanelforviewrequets, this);
                        }
                    }
                }
                else
                {
                    if (checkBoxforincludesdatefromdatapicker.Checked)
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Выполнен");
                        }
                        else if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Отклонена");
                        }
                        else if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Принят");
                        }
                        else if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingrequestbydateandtatus(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this, "Ожидание");
                        }
                        else
                        {
                            methodforsortingrequestbydate(login, userpriviligies, flowLayoutPanelforviewrequets, DateTimePickerforsortingrequests, this);
                        }
                    }
                    else
                    {
                        if (radioButtonforstatuscomplete.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Выполнен", this);
                        }
                        else if (radioButtonfordeniedstatus.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Отклонена", this);
                        }
                        else if (radioButtonforappliedstatus.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Принят", this);
                        }
                        else if (radioButtonforwaitstatus.Checked)
                        {
                            methodforsortingloadinglistrequest(login, userpriviligies, flowLayoutPanelforviewrequets, "Ожидание", this);
                        }
                        else
                        {
                            refreshlistrequestcreatedbytheworker(login, userpriviligies, this, flowLayoutPanelforviewrequets);
                        }
                    }
                }
            }
        }
    }
}
