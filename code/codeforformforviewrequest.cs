using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace DailyPlanner.code
{
    internal static class codeforformforviewrequest
    {
        internal static void methodforviewdetailedinformationavoutrequest(
            int idRequest,
            string userprivilige,
            Panel panelforplaceGUIobject,
            Label labelforidrequest,
            Label labelforauthorequest,
            Label labelforcompanyapplicant,
            Label labelforserviceapplicant,
            Label labelfordepartmentapplicant,
            Label labelforfullnameapplicant,
            Label labelforlocationapplicant,
            Label labelforroomapplicant,
            Label labelforcontactphoneapplicant,
            Label labelforsubjectrequest,
            Label labelforRDPauthorPC,
            Label labelforrdateofequestsubmission,
            Label labelforlastmodifieddate,
            Label labelfordescriptionrequest,
            Form activeform
            )
        {
            if (userprivilige == "worker")
            {
                string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                Label labelforrequiredservice = new Label
                {
                    Text = "label",
                    Size = new Size(65, 25),
                    AutoSize = true,
                    Location = new Point(3, 329),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                };

                labelforrequiredservice.Name = "labelforrequiredservice";

                Label labelforstatusrequest = new Label
                {
                    Text = "label",
                    Size = new Size(65, 25),
                    AutoSize = true,
                    Location = new Point(1, 481),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                };

                labelforstatusrequest.Name = "labelforstatusrequest";

                Label Labelfortechnicalstaffresponse = new Label
                {
                    Text = "label",
                    Size = new Size(716, 97),
                    AutoSize = false,
                    Location = new Point(3, 633),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                };

                Labelfortechnicalstaffresponse.Name = "Labelfortechnicalstaffresponse";

                panelforplaceGUIobject.Controls.Add(labelforrequiredservice);
                panelforplaceGUIobject.Controls.Add(labelforstatusrequest);
                panelforplaceGUIobject.Controls.Add(Labelfortechnicalstaffresponse);

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                    {
                        conn.Open();

                        using (var commandforloaddetailedinformationaboutrequest = new NpgsqlCommand("select \"ID request\", \"Author\", \"Applicant’s company\", \"Applicant’s service\", \"Applicant’s department\", \"Applicant’s full name\", \"Applicant’s location\", \"Applicant’s room\", \"Applicant’s contact phone\", \"Subject of the application\", \"Required service\", \"RDP author PC\", \"Date of request submission\", \"Last modified date\", \"Request status\", \"Description request\", \"Technical staff response\" from \"Request\" where \"ID request\" = @id;", conn))
                        {
                            commandforloaddetailedinformationaboutrequest.Parameters.AddWithValue("id", NpgsqlDbType.Integer, idRequest);

                            using (var readercommandforloaddetailedinformationaboutrequest = commandforloaddetailedinformationaboutrequest.ExecuteReader())
                            {
                                if (readercommandforloaddetailedinformationaboutrequest.Read())
                                {
                                    labelforidrequest.Text = readercommandforloaddetailedinformationaboutrequest.GetInt32(0).ToString();
                                    labelforauthorequest.Text = readercommandforloaddetailedinformationaboutrequest.GetString(1);
                                    labelforcompanyapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(2);
                                    labelforserviceapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(3);
                                    labelfordepartmentapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(4);
                                    labelforfullnameapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(5);
                                    labelforlocationapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(6);
                                    labelforroomapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(7);
                                    labelforcontactphoneapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(8);
                                    labelforsubjectrequest.Text = readercommandforloaddetailedinformationaboutrequest.GetString(9);
                                    labelforrequiredservice.Text = readercommandforloaddetailedinformationaboutrequest.GetString(10);
                                    labelforRDPauthorPC.Text = readercommandforloaddetailedinformationaboutrequest.GetString(11);
                                    labelforrdateofequestsubmission.Text = readercommandforloaddetailedinformationaboutrequest.GetDateTime(12).ToString();
                                    labelforlastmodifieddate.Text = readercommandforloaddetailedinformationaboutrequest.GetDateTime(13).ToString();
                                    labelforstatusrequest.Text = readercommandforloaddetailedinformationaboutrequest.GetString(14);
                                    labelfordescriptionrequest.Text = readercommandforloaddetailedinformationaboutrequest.IsDBNull(15) ? "" : readercommandforloaddetailedinformationaboutrequest.GetString(15);
                                    Labelfortechnicalstaffresponse.Text = readercommandforloaddetailedinformationaboutrequest.IsDBNull(16) ? "" : readercommandforloaddetailedinformationaboutrequest.GetString(16);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Нету соединение с базой данных", "Система");
                    activeform.Close();
                }
            }
            else if (userprivilige == "worker by request")
            {
                string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                ComboBox ComboBoxforrequiredservice = new ComboBox
                {
                    Size = new Size(panelforplaceGUIobject.ClientSize.Width - 100, 31),
                    AutoSize = false,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(3, 330),
                    TabIndex = 0
                    
                };

                ComboBoxforrequiredservice.Name = "comboboxforservice";

                ComboBox ComboBoxforstatusrequest = new ComboBox
                {
                    Size = new Size(panelforplaceGUIobject.ClientSize.Width - 100, 31),
                    AutoSize = false,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(1, 481),
                    TabIndex = 1
                };

                ComboBoxforstatusrequest.Name = "comboboxforstatus";

                TextBox textBoxfortechnicalstaffresponse = new TextBox
                {
                    Size = new Size(716, 97),
                    Multiline = true,
                    AutoSize = false,
                    Location = new Point(3, 630),
                    TabIndex = 2,
                    MaxLength = 300
                };

                textBoxfortechnicalstaffresponse.Name = "textBoxfortechnicalstaffresponse";

                panelforplaceGUIobject.Controls.Add(ComboBoxforrequiredservice);
                panelforplaceGUIobject.Controls.Add(ComboBoxforstatusrequest);
                panelforplaceGUIobject.Controls.Add(textBoxfortechnicalstaffresponse);

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                    {
                        conn.Open();

                        using (var commandforloaddetailedinformationaboutrequest = new NpgsqlCommand("select \"ID request\", \"Author\", \"Applicant’s company\", \"Applicant’s service\", \"Applicant’s department\", \"Applicant’s full name\", \"Applicant’s location\", \"Applicant’s room\", \"Applicant’s contact phone\", \"Subject of the application\", \"Required service\", \"RDP author PC\", \"Date of request submission\", \"Last modified date\", \"Request status\", \"Description request\", \"Technical staff response\" from \"Request\" where \"ID request\" = @id;", conn))
                        {
                            commandforloaddetailedinformationaboutrequest.Parameters.AddWithValue("id", NpgsqlDbType.Integer, idRequest);

                            using (var readercommandforloaddetailedinformationaboutrequest = commandforloaddetailedinformationaboutrequest.ExecuteReader())
                            {
                                if (readercommandforloaddetailedinformationaboutrequest.Read())
                                {
                                    labelforidrequest.Text = readercommandforloaddetailedinformationaboutrequest.GetInt32(0).ToString();
                                    labelforauthorequest.Text = readercommandforloaddetailedinformationaboutrequest.GetString(1);
                                    labelforcompanyapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(2);
                                    labelforserviceapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(3);
                                    labelfordepartmentapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(4);
                                    labelforfullnameapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(5);
                                    labelforlocationapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(6);
                                    labelforroomapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(7);
                                    labelforcontactphoneapplicant.Text = readercommandforloaddetailedinformationaboutrequest.GetString(8);
                                    labelforsubjectrequest.Text = readercommandforloaddetailedinformationaboutrequest.GetString(9);
                                    ComboBoxforrequiredservice.Items.Add(readercommandforloaddetailedinformationaboutrequest.GetString(10));
                                    ComboBoxforrequiredservice.Tag = readercommandforloaddetailedinformationaboutrequest.GetString(10);
                                    labelforRDPauthorPC.Text = readercommandforloaddetailedinformationaboutrequest.GetString(11);
                                    labelforrdateofequestsubmission.Text = readercommandforloaddetailedinformationaboutrequest.GetDateTime(12).ToString();
                                    labelforlastmodifieddate.Text = readercommandforloaddetailedinformationaboutrequest.GetDateTime(13).ToString();
                                    ComboBoxforstatusrequest.Items.Add(readercommandforloaddetailedinformationaboutrequest.GetString(14));
                                    ComboBoxforstatusrequest.Tag = readercommandforloaddetailedinformationaboutrequest.GetString(14);
                                    labelfordescriptionrequest.Text = readercommandforloaddetailedinformationaboutrequest.IsDBNull(15) ? "" : readercommandforloaddetailedinformationaboutrequest.GetString(15);
                                    textBoxfortechnicalstaffresponse.Text = readercommandforloaddetailedinformationaboutrequest.IsDBNull(16) ? "" : readercommandforloaddetailedinformationaboutrequest.GetString(16);
                                    textBoxfortechnicalstaffresponse.Tag = readercommandforloaddetailedinformationaboutrequest.IsDBNull(16) ? "" : readercommandforloaddetailedinformationaboutrequest.GetString(16);
                                }
                            }
                        }

                        ComboBoxforrequiredservice.SelectedIndex = 0;
                        ComboBoxforstatusrequest.SelectedIndex = 0;

                        using (var commandforfillcomboboxinsidewhomplacerequiredservice = new NpgsqlCommand("select s.\"Name required service\" from \"List of equipment\" e join \"List of required services\" s on s.\"ID equipment\" = e.\"ID equipment\" where e.\"Name equipment\" = @equipment;", conn))
                        {
                            commandforfillcomboboxinsidewhomplacerequiredservice.Parameters.AddWithValue("equipment", NpgsqlDbType.Varchar, labelforsubjectrequest.Text);

                            using (var readerforcommandforfillcomboboxinsidewhomplacerequiredservice = commandforfillcomboboxinsidewhomplacerequiredservice.ExecuteReader())
                            {
                                while (readerforcommandforfillcomboboxinsidewhomplacerequiredservice.Read())
                                {
                                    if (ComboBoxforrequiredservice.Text != readerforcommandforfillcomboboxinsidewhomplacerequiredservice.GetString(0))
                                    {
                                        ComboBoxforrequiredservice.Items.Add(readerforcommandforfillcomboboxinsidewhomplacerequiredservice.GetString(0));
                                    }
                                }
                            }
                        }

                        using (var commandforfillcomboboxinsidewhomplacestatusrequest = new NpgsqlCommand("select \"Status name\" from \"Possible status request\";", conn))
                        {
                            using (var readerforcommandforfillcomboboxinsidewhomplacestatusrequest = commandforfillcomboboxinsidewhomplacestatusrequest.ExecuteReader())
                            {
                                while (readerforcommandforfillcomboboxinsidewhomplacestatusrequest.Read())
                                {
                                    if (ComboBoxforstatusrequest.Text != readerforcommandforfillcomboboxinsidewhomplacestatusrequest.GetString(0))
                                    {
                                        ComboBoxforstatusrequest.Items.Add(readerforcommandforfillcomboboxinsidewhomplacestatusrequest.GetString(0));
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                    activeform.Close();
                }
            }
        }

        internal static void methodforapplychangeinformationaboutrequest(string login, int idRequest, ComboBox ComboBoxforrequiredservice, ComboBox ComboBoxforstatusrequest, Label labelforidrequest, Form activeform, TextBox textBoxfortechnicalstaffresponse)
        {
            if (MessageBox.Show("Вы уверены в том, что вы хотите сохранить изменения в заявке?", "Система", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if ((ComboBoxforrequiredservice.SelectedIndex != 0 && ComboBoxforstatusrequest.SelectedIndex != 0 && textBoxfortechnicalstaffresponse.Text != textBoxfortechnicalstaffresponse.Tag.ToString()) || (ComboBoxforrequiredservice.SelectedIndex == 0 && ComboBoxforstatusrequest.SelectedIndex != 0 && textBoxfortechnicalstaffresponse.Text != textBoxfortechnicalstaffresponse.Tag.ToString()) || (ComboBoxforrequiredservice.SelectedIndex != 0 && ComboBoxforstatusrequest.SelectedIndex == 0 && textBoxfortechnicalstaffresponse.Text != textBoxfortechnicalstaffresponse.Tag.ToString()) || (ComboBoxforrequiredservice.SelectedIndex == 0 && ComboBoxforstatusrequest.SelectedIndex == 0 && textBoxfortechnicalstaffresponse.Text != textBoxfortechnicalstaffresponse.Tag.ToString()))
                {
                    if ((ComboBoxforstatusrequest.Text == "Принят" || ComboBoxforstatusrequest.Text == "Выполнен" || ComboBoxforstatusrequest.Text == "Отклонена") && ComboBoxforrequiredservice.SelectedIndex != 0)
                    {
                        MessageBox.Show("Вы пытаетесь перенаправить заявку со статусом, отличным от \"Ожидание\"", "Система");
                    }
                    else if (string.IsNullOrWhiteSpace(textBoxfortechnicalstaffresponse.Text) || string.IsNullOrEmpty(textBoxfortechnicalstaffresponse.Text))
                    {
                        MessageBox.Show("Введите ответ пользователю", "Система");
                    }
                    else
                    {
                        string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";
                        int? intforidworker = null;

                        try
                        {
                            using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                            {
                                conn.Open();

                                using (var transaction = conn.BeginTransaction())
                                {
                                    try
                                    {
                                        if (ComboBoxforrequiredservice.SelectedIndex != 0 && ComboBoxforstatusrequest.Text == "Ожидание")
                                        {
                                            using (var grabid = new NpgsqlCommand("select \"ID worker\" from \"List of workers accounts\" where \"Login\" = @login", conn,transaction))
                                            {
                                                grabid.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);

                                                intforidworker = (int)grabid.ExecuteScalar();
                                            }

                                            using (var commandforlog = new NpgsqlCommand("SELECT set_config('daily_planner.current_user', @workerId, true);", conn, transaction))
                                            {
                                                commandforlog.Parameters.AddWithValue("workerId", NpgsqlDbType.Varchar, Convert.ToString(intforidworker));

                                                commandforlog.ExecuteNonQuery();
                                            }

                                            using (var commandforapplychangeinformationtwofields = new NpgsqlCommand("update \"Request\" set \"Request status\" = @requiredstatus, \"Required service\" = @requiredservice, \"Last modified date\" = now(), \"Technical staff response\" = @technicalstaffresponse where \"ID request\" = @idrequest;", conn, transaction))
                                            {
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("requiredservice", NpgsqlDbType.Varchar, ComboBoxforrequiredservice.Text);
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("idrequest", NpgsqlDbType.Integer, Convert.ToInt32(labelforidrequest.Text));
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("technicalstaffresponse", NpgsqlDbType.Varchar, textBoxfortechnicalstaffresponse.Text);
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("requiredstatus", NpgsqlDbType.Varchar, ComboBoxforstatusrequest.Text);


                                                commandforapplychangeinformationtwofields.ExecuteNonQuery();
                                            }
                                        }
                                        else if (ComboBoxforrequiredservice.SelectedIndex == 0 && ComboBoxforstatusrequest.SelectedIndex != 0)
                                        {
                                            using (var grabid = new NpgsqlCommand("select \"ID worker\" from \"List of workers accounts\" where \"Login\" = @login", conn, transaction))
                                            {
                                                grabid.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);

                                                intforidworker = (int)grabid.ExecuteScalar();
                                            }

                                            using (var commandforlog = new NpgsqlCommand("SELECT set_config('daily_planner.current_user', @workerId, true);", conn, transaction))
                                            {
                                                commandforlog.Parameters.AddWithValue("workerId", NpgsqlDbType.Varchar, Convert.ToString(intforidworker));

                                                commandforlog.ExecuteNonQuery();
                                            }

                                            using (var commandforapplychangeinformationtwofields = new NpgsqlCommand("update \"Request\" set \"Request status\" = @requiredstatus, \"Required service\" = @requiredservice, \"Last modified date\" = now(), \"Technical staff response\" = @technicalstaffresponse where \"ID request\" = @idrequest;", conn, transaction))
                                            {
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("requiredstatus", NpgsqlDbType.Varchar, ComboBoxforstatusrequest.Text);
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("idrequest", NpgsqlDbType.Integer, Convert.ToInt32(labelforidrequest.Text));
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("technicalstaffresponse", NpgsqlDbType.Varchar, textBoxfortechnicalstaffresponse.Text);
                                                commandforapplychangeinformationtwofields.Parameters.AddWithValue("requiredservice", NpgsqlDbType.Varchar, ComboBoxforrequiredservice.Text);


                                                commandforapplychangeinformationtwofields.ExecuteNonQuery();
                                            }
                                        }

                                        transaction.Commit();
                                    }
                                    catch
                                    { 
                                        MessageBox.Show("Ошибка соединения с базой данных", "Система");
                                        transaction.Rollback();
                                    }
                                }
                            }

                            activeform.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка соединения с базой данных", "Система");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вы ничего не изменили или не добавили ответ пользователю или не изменили ответ", "Система");
                }
            }
        }

        internal static void createworddoc(string userpriviles, Label idrequest, ComboBox listservice, ComboBox liststatus, Label name, Label company, Label service, Label department, Label location, Label phone, Label requestobject, Label ip, Label createdate, Label reactdate, Label description, Label labelservice, Label labelstatus, Label ltechresponse, TextBox ttechresponse)
        {
            if (MessageBox.Show("Вы уверены в том, что вы хотите экспортировать заявку в формат word'а?", "Система", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (userpriviles == "worker")
                {
                    SaveFileDialog sfdforworker = new SaveFileDialog();
                    sfdforworker.Filter = "Word документ|*.docx"; //типо сначала описание потом метка для системы
                    sfdforworker.FileName = $"Заявка №{idrequest.Text}";

                    if (sfdforworker.ShowDialog() == DialogResult.OK)
                    {
                        using (var doc = DocX.Create(sfdforworker.FileName))
                        {
                            Bitmap resourceImage = Properties.Resources.resizepicture_;

                            using (MemoryStream ms = new MemoryStream())
                            {
                                resourceImage.Save(ms, ImageFormat.Png);
                                ms.Seek(0, SeekOrigin.Begin);

                                Xceed.Document.NET.Image img = doc.AddImage(ms);

                                Picture pic = img.CreatePicture();
                                pic.Width = 67;
                                pic.Height = 65;

                                var table = doc.AddTable(1, 2);
                                table.Design = TableDesign.None;
                                table.Rows[0].Cells[0].Paragraphs[0].AppendPicture(pic);
                                table.Rows[0].Cells[1].Paragraphs[0].Append("Система Daily Planner \n Дата формирования: " + DateTime.Now.ToShortDateString()).Font("Comic Sans MS").FontSize(12).Alignment = Alignment.right;
                                doc.InsertTable(table);
                            }

                            doc.InsertParagraph().SpacingAfter(10);
                            doc.InsertParagraph("Заявка").Font("Comic Sans MS").FontSize(25).Bold();
                            doc.InsertParagraph().SpacingAfter(2);

                            doc.InsertParagraph($"Идентификатор заявки: {idrequest.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Имя автора заявки: {name.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Компания: {company.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Служба: {service.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Отдел: {department.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Локация: {location.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Контактный телефон: {phone.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Обьект заявки: {requestobject.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Необходимый сервис: {labelservice.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"IP компьютера: {ip.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Дата создания заявки: {createdate.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Дата последнего изменения заявки: {reactdate.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Статус заявки: {labelstatus.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Описание заявки: {description.Text}").Font("Comic Sans MS").FontSize(14);
                            doc.InsertParagraph($"Ответ технического персонала: {ltechresponse.Text}").Font("Comic Sans MS").FontSize(14);

                            doc.Save();
                        }
                        MessageBox.Show("Файл сохранен!");
                    }
                }
                else if (userpriviles == "worker by request")
                {
                    if (listservice.Text == listservice.Tag.ToString() && liststatus.Text == liststatus.Tag.ToString() && ttechresponse.Text == ttechresponse.Tag.ToString())
                    {
                        SaveFileDialog sfdforworkerbyrequest = new SaveFileDialog();
                        sfdforworkerbyrequest.Filter = "Word документ|*.docx"; //типо сначала описание потом метка для системы
                        sfdforworkerbyrequest.FileName = $"Заявка №{idrequest.Text}";

                        if (sfdforworkerbyrequest.ShowDialog() == DialogResult.OK)
                        {
                            using (var doc = DocX.Create(sfdforworkerbyrequest.FileName))
                            {
                                Bitmap resourceImage = Properties.Resources.resizepicture_;

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    resourceImage.Save(ms, ImageFormat.Png);
                                    ms.Seek(0, SeekOrigin.Begin);

                                    Xceed.Document.NET.Image img = doc.AddImage(ms);

                                    Picture pic = img.CreatePicture();
                                    pic.Width = 67;
                                    pic.Height = 65;

                                    var table = doc.AddTable(1, 2);
                                    table.Design = TableDesign.None;
                                    table.Rows[0].Cells[0].Paragraphs[0].AppendPicture(pic);
                                    table.Rows[0].Cells[1].Paragraphs[0].Append("Система Daily Planner \n Дата формирования: " + DateTime.Now.ToShortDateString()).Font("Comic Sans MS").FontSize(12).Alignment = Alignment.right;
                                    doc.InsertTable(table);
                                }

                                doc.InsertParagraph().SpacingAfter(10);
                                doc.InsertParagraph("Заявка").Font("Comic Sans MS").FontSize(25).Bold();
                                doc.InsertParagraph().SpacingAfter(2);

                                doc.InsertParagraph($"Идентификатор заявки: {idrequest.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Имя автора заявки: {name.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Компания: {company.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Служба: {service.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Отдел: {department.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Локация: {location.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Контактный телефон: {phone.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Обьект заявки: {requestobject.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Необходимый сервис: {listservice.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"IP компьютера: {ip.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Дата создания заявки: {createdate.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Дата последнего изменения заявки: {reactdate.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Статус заявки: {liststatus.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Описание заявки: {description.Text}").Font("Comic Sans MS").FontSize(14);
                                doc.InsertParagraph($"Ответ технического персонала: {ttechresponse.Text}").Font("Comic Sans MS").FontSize(14);

                                doc.Save();
                            }
                            MessageBox.Show("Файл сохранен!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы изменили данные и не сохранили их", "Система");
                    }
                }
            }
        }
    }
}
