using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace DailyPlanner.code
{
    internal static class codeformforworker
    {
        internal static Control createrequestcard(Form form, FlowLayoutPanel mainflow, string userprivilige, int id, string requiredservice, string author, DateTime date, string status, string login)
        {
            var panel = new Panel
            {
                Width = mainflow.ClientSize.Width - 25,
                BorderStyle = BorderStyle.FixedSingle,
                Height = 125,
                Tag = (id, form, userprivilige, login)
            };

            var labelforid = new Label
            {
                Text = $"Идентификатор заявки - {id}",
                AutoSize = true,
                Location = new Point(5,5)
            };

            var labelforrequiredservice = new Label
            {
                Text = requiredservice,
                AutoSize = true,
                Location = new Point(5, 25)
            };

            var labelforauthor = new Label
            {
                Text = $"Автор - {author}",
                AutoSize = true,
                Location = new Point(5, 45)
            };

            var labelfordate = new Label
            {
                Text = $"Дата редакции заявки - {date}",
                AutoSize = true,
                Location = new Point(5, 65)
            };

            var labelforstatus = new Label
            {
                Text = $"Статус заявки - {status}",
                AutoSize = true,
                Location = new Point(5, 85)
            };

            panel.Controls.Add(labelforid);
            panel.Controls.Add(labelforrequiredservice);
            panel.Controls.Add(labelforauthor);
            panel.Controls.Add(labelfordate);
            panel.Controls.Add(labelforstatus);

            panel.Click += RequestCard_Click;
            foreach (Control c in panel.Controls)
            {
                c.Click += (s, e) => RequestCard_Click(panel, e);
            }  

            return panel;
        }

        private static void RequestCard_Click(object sender, EventArgs e)
        {
            var panel = (Panel)sender;

            var datafrompanel = ((int id, Form formfrompanel, string userprivilige, string login))panel.Tag;

            int idRequest = datafrompanel.id;
            Form activeform = datafrompanel.formfrompanel;
            string usergroup = datafrompanel.userprivilige;
            string Login = datafrompanel.login;

            using (var formforcreatedialog = new formforviewrequest(idRequest, usergroup, Login))
            {
                formforcreatedialog.ShowDialog(activeform);

                if (activeform is formforworker mainForm)
                {
                    mainForm.methodforrefreshfromcs();
                }
            }
        }

        internal static void refreshlistrequestcreatedbytheworker(string login, string userprivilige, Form formwhocall, FlowLayoutPanel mainflow)
        {
            mainflow.Controls.Clear();

            if (userprivilige == "worker")
            {
                string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestworker = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestworker.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);

                            using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestworker.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestworker.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
            else if (userprivilige == "worker by request")
            {
                string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestforworkerbyrequest = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"Request\" r join \"List of required services\" rs on rs.\"ID required service\" = r.\"ID required service\" join \"List of required service category\" sc on sc.\"ID required service category\" = rs.\"ID required service category\" join \"List of departments\" d on d.\"ID department\" = sc.\"ID department\" join \"List of workers accounts\" a on a.\"Login\" = @login join \"List of workers\" w on w.\"ID worker\" = a.\"ID worker\" where d.\"ID department\" = w.\"ID department\" order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);

                            using (var readerforcommandforloadlistrequestforworkerbyrequest = commandforloadlistrequestforworkerbyrequest.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestforworkerbyrequest.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestforworkerbyrequest.GetInt32(0), readerforcommandforloadlistrequestforworkerbyrequest.GetString(1), readerforcommandforloadlistrequestforworkerbyrequest.GetString(2), readerforcommandforloadlistrequestforworkerbyrequest.GetDateTime(3), readerforcommandforloadlistrequestforworkerbyrequest.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
        }

        internal static void methodforsortingloadinglistrequest(string login, string userprivilige, FlowLayoutPanel mainflow, string conditionsorting, Form formwhocall)
        {
            mainflow.Controls.Clear();

            if (userprivilige == "worker")
            {
                string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestworker = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login and r.\"Request status\" = @status order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestworker.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);
                            commandforloadlistrequestworker.Parameters.AddWithValue("status", NpgsqlDbType.Varchar, conditionsorting);

                            using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestworker.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestworker.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
            else if (userprivilige == "worker by request")
            {
                string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestforworkerbyrequest = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"Request\" r join \"List of required services\" rs on rs.\"ID required service\" = r.\"ID required service\" join \"List of required service category\" sc on sc.\"ID required service category\" = rs.\"ID required service category\" join \"List of departments\" d on d.\"ID department\" = sc.\"ID department\" join \"List of workers accounts\" a on a.\"Login\" = @login join \"List of workers\" w on w.\"ID worker\" = a.\"ID worker\" where d.\"ID department\" = w.\"ID department\" and r.\"Request status\" = @status order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("status", NpgsqlDbType.Varchar, conditionsorting);

                            using (var readerforcommandforloadlistrequestforworkerbyrequest = commandforloadlistrequestforworkerbyrequest.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestforworkerbyrequest.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestforworkerbyrequest.GetInt32(0), readerforcommandforloadlistrequestforworkerbyrequest.GetString(1), readerforcommandforloadlistrequestforworkerbyrequest.GetString(2), readerforcommandforloadlistrequestforworkerbyrequest.GetDateTime(3), readerforcommandforloadlistrequestforworkerbyrequest.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
        }

        internal static void methodforsortingloadingbyself(string login, string userprivilige, FlowLayoutPanel mainflow, Form formwhocall)
        {
            string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

            mainflow.Controls.Clear();

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                {
                    conn.Open();

                    using (var commandforloadlistrequestworker = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login order by r.\"Last modified date\" desc;", conn))
                    {
                        commandforloadlistrequestworker.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);

                        using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestworker.ExecuteReader())
                        {
                            while (readerforcommandforloadlistrequestworker.Read())
                            {
                                mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных", "Система");
            }
        }

        internal static void methodforsortingloadingbyselfandbystatus(string login, string userprivilige, FlowLayoutPanel mainflow, string conditionsorting, Form formwhocall)
        {
            mainflow.Controls.Clear();

            string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                {
                    conn.Open();

                    using (var commandforloadlistrequestworker = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login and r.\"Request status\" = @status order by r.\"Last modified date\" desc;", conn))
                    {
                        commandforloadlistrequestworker.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);
                        commandforloadlistrequestworker.Parameters.AddWithValue("status", NpgsqlDbType.Varchar, conditionsorting);

                        using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestworker.ExecuteReader())
                        {
                            while (readerforcommandforloadlistrequestworker.Read())
                            {
                                mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных", "Система");
            }
        }

        internal static void methodforsortingrequestbydate(string login, string userprivilige, FlowLayoutPanel mainflow, DateTimePicker date, Form formwhocall)
        {
            mainflow.Controls.Clear();

            if (userprivilige == "worker")
            {
                string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestworker = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login and r.\"Date of request submission\" >= @date and r.\"Date of request submission\" < @dateEnd order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestworker.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);
                            commandforloadlistrequestworker.Parameters.AddWithValue("date", NpgsqlDbType.Date, date.Value.Date);
                            commandforloadlistrequestworker.Parameters.AddWithValue("dateEnd", NpgsqlDbType.Date, date.Value.Date.AddDays(1));

                            using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestworker.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestworker.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
            else if (userprivilige == "worker by request")
            {
                string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestforworkerbyrequest = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"Request\" r join \"List of required services\" rs on rs.\"ID required service\" = r.\"ID required service\" join \"List of required service category\" sc on sc.\"ID required service category\" = rs.\"ID required service category\" join \"List of departments\" d on d.\"ID department\" = sc.\"ID department\" join \"List of workers accounts\" a on a.\"Login\" = @login join \"List of workers\" w on w.\"ID worker\" = a.\"ID worker\" where d.\"ID department\" = w.\"ID department\" and r.\"Date of request submission\" >= @date and r.\"Date of request submission\" < @dateEnd order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("date", NpgsqlDbType.Date, date.Value.Date);
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("dateEnd", NpgsqlDbType.Date, date.Value.Date.AddDays(1));

                            using (var readerforcommandforloadlistrequestforworkerbyrequest = commandforloadlistrequestforworkerbyrequest.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestforworkerbyrequest.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestforworkerbyrequest.GetInt32(0), readerforcommandforloadlistrequestforworkerbyrequest.GetString(1), readerforcommandforloadlistrequestforworkerbyrequest.GetString(2), readerforcommandforloadlistrequestforworkerbyrequest.GetDateTime(3), readerforcommandforloadlistrequestforworkerbyrequest.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
        }

        internal static void methodforsortingrequestbydateandtatus(string login, string userprivilige, FlowLayoutPanel mainflow, DateTimePicker date, Form formwhocall, string conditionsorting)
        {
            mainflow.Controls.Clear();

            if (userprivilige == "worker")
            {
                string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestworker = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login and r.\"Date of request submission\" >= @date and r.\"Date of request submission\" < @dateEnd and r.\"Request status\" = @status order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestworker.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);
                            commandforloadlistrequestworker.Parameters.AddWithValue("date", NpgsqlDbType.Date, date.Value.Date);
                            commandforloadlistrequestworker.Parameters.AddWithValue("dateEnd", NpgsqlDbType.Date, date.Value.Date.AddDays(1));
                            commandforloadlistrequestworker.Parameters.AddWithValue("status", NpgsqlDbType.Varchar, conditionsorting);

                            using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestworker.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestworker.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
            else if (userprivilige == "worker by request")
            {
                string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                    {
                        conn.Open();

                        using (var commandforloadlistrequestforworkerbyrequest = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"Request\" r join \"List of required services\" rs on rs.\"ID required service\" = r.\"ID required service\" join \"List of required service category\" sc on sc.\"ID required service category\" = rs.\"ID required service category\" join \"List of departments\" d on d.\"ID department\" = sc.\"ID department\" join \"List of workers accounts\" a on a.\"Login\" = @login join \"List of workers\" w on w.\"ID worker\" = a.\"ID worker\" where d.\"ID department\" = w.\"ID department\" and r.\"Date of request submission\" >= @date and r.\"Date of request submission\" < @dateEnd and r.\"Request status\" = @status order by r.\"Last modified date\" desc;", conn))
                        {
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("date", NpgsqlDbType.Date, date.Value);
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("date", NpgsqlDbType.Date, date.Value.Date);
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("dateEnd", NpgsqlDbType.Date, date.Value.Date.AddDays(1));
                            commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("status", NpgsqlDbType.Varchar, conditionsorting);

                            using (var readerforcommandforloadlistrequestforworkerbyrequest = commandforloadlistrequestforworkerbyrequest.ExecuteReader())
                            {
                                while (readerforcommandforloadlistrequestforworkerbyrequest.Read())
                                {
                                    mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestforworkerbyrequest.GetInt32(0), readerforcommandforloadlistrequestforworkerbyrequest.GetString(1), readerforcommandforloadlistrequestforworkerbyrequest.GetString(2), readerforcommandforloadlistrequestforworkerbyrequest.GetDateTime(3), readerforcommandforloadlistrequestforworkerbyrequest.GetString(4), login));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой данных", "Система");
                }
            }
        }

        internal static void methodforsortingrequestbycreatemyselfanddateandstatus(string login, string userprivilige, FlowLayoutPanel mainflow, DateTimePicker date, Form formwhocall, string conditionsorting)
        {
            mainflow.Controls.Clear();

            string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                {
                    conn.Open();

                    using (var commandforloadlistrequestforworkerbyrequest = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login and r.\"Date of request submission\" >= @date and r.\"Date of request submission\" < @dateEnd and r.\"Request status\" = @status order by r.\"Last modified date\" desc;", conn))
                    {
                        commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);
                        commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("date", NpgsqlDbType.Date, date.Value.Date);
                        commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("dateEnd", NpgsqlDbType.Date, date.Value.Date.AddDays(1));
                        commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("status", NpgsqlDbType.Varchar, conditionsorting);

                        using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestforworkerbyrequest.ExecuteReader())
                        {
                            while (readerforcommandforloadlistrequestworker.Read())
                            {
                                mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных", "Система");
            }
        }

        internal static void methodforsortingrequestbycreatemyselfanddate(string login, string userprivilige, FlowLayoutPanel mainflow, DateTimePicker date, Form formwhocall)
        {
            mainflow.Controls.Clear();

            string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                {
                    conn.Open();

                    using (var commandforloadlistrequestforworkerbyrequest = new NpgsqlCommand("select r.\"ID request\", r.\"Required service\", r.\"Author\", r.\"Last modified date\", r.\"Request status\" from \"List of workers accounts\" a join \"Request\" r on r.\"Applicant’s id\" = a.\"ID worker\" where a.\"Login\" = @Login and r.\"Date of request submission\" >= @date and r.\"Date of request submission\" < @dateEnd  order by r.\"Last modified date\" desc;", conn))
                    {
                        commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("Login", NpgsqlDbType.Varchar, login);
                        commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("date", NpgsqlDbType.Date, date.Value.Date);
                        commandforloadlistrequestforworkerbyrequest.Parameters.AddWithValue("dateEnd", NpgsqlDbType.Date, date.Value.Date.AddDays(1));

                        using (var readerforcommandforloadlistrequestworker = commandforloadlistrequestforworkerbyrequest.ExecuteReader())
                        {
                            while (readerforcommandforloadlistrequestworker.Read())
                            {
                                mainflow.Controls.Add(createrequestcard(formwhocall, mainflow, userprivilige, readerforcommandforloadlistrequestworker.GetInt32(0), readerforcommandforloadlistrequestworker.GetString(1), readerforcommandforloadlistrequestworker.GetString(2), readerforcommandforloadlistrequestworker.GetDateTime(3), readerforcommandforloadlistrequestworker.GetString(4), login));
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных", "Система");
            }
        }
    }
}
