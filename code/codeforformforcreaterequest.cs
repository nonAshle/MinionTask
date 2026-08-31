using Microsoft.VisualBasic.Logging;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPlanner.code
{
    internal static class codeforformforcreaterequest
    {
        internal static void loaddataforlistquipmentworkerfromdatabase(string login, string userPrivilige, ComboBox comboboxforlistequipmentworker, Form activeform)
        {
            comboboxforlistequipmentworker.Items.Clear();  

            if (userPrivilige == "worker")
            {
                string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                    {
                        conn.Open();

                        using (var commandforloadlistequipmentworkerfromdatabase = new NpgsqlCommand("select e.\"Name equipment\" || ' | Инвентарный номер: ' || ee.\"Inventory number equipment\" from \"List of equipment\" e join \"Employee equipment\" ee on ee.\"ID equipment\" = e.\"ID equipment\" join \"List of workers accounts\" wa on wa.\"ID worker\" = ee.\"ID worker\" where wa.\"Login\" = @login order by ee.\"ID equipment\" asc;", conn))
                        {
                            commandforloadlistequipmentworkerfromdatabase.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);

                            using (var readercommandforloadlistequipmentworkerfromdatabase = commandforloadlistequipmentworkerfromdatabase.ExecuteReader())
                            {
                                while (readercommandforloadlistequipmentworkerfromdatabase.Read())
                                {
                                    comboboxforlistequipmentworker.Items.Add(readercommandforloadlistequipmentworkerfromdatabase.GetString(0));
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
            else if (userPrivilige == "worker by request")
            {
                string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                    {
                        conn.Open();

                        using (var commandforloadlistequipmentworkerfromdatabase = new NpgsqlCommand("select e.\"Name equipment\" || ' | Инвентарный номер: ' || ee.\"Inventory number equipment\" from \"List of equipment\" e join \"Employee equipment\" ee on ee.\"ID equipment\" = e.\"ID equipment\" join \"List of workers accounts\" wa on wa.\"ID worker\" = ee.\"ID worker\" where wa.\"Login\" = @login order by ee.\"ID equipment\" asc;", conn))
                        {
                            commandforloadlistequipmentworkerfromdatabase.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);

                            using (var readercommandforloadlistequipmentworkerfromdatabase = commandforloadlistequipmentworkerfromdatabase.ExecuteReader())
                            {
                                while (readercommandforloadlistequipmentworkerfromdatabase.Read())
                                {
                                    comboboxforlistequipmentworker.Items.Add(readercommandforloadlistequipmentworkerfromdatabase.GetString(0));
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

        internal static void loaddataforrequiredservice(string userPrivilige, ComboBox comboboxforlistrequiredservice, ComboBox comboboxforlistequipmentworker)
        {
            comboboxforlistrequiredservice.Text = string.Empty;
            comboboxforlistrequiredservice.Items.Clear();

            if (userPrivilige == "worker")
            {
                string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                    {
                        conn.Open();

                        using (var commandforloadlistequipmentworkerfromdatabase = new NpgsqlCommand("select rs.\"Name required service\" from \"List of required services\" rs join \"List of equipment\" e on e.\"ID equipment\" = rs.\"ID equipment\" where e.\"Name equipment\" = @equipmentName order by rs.\"Name required service\" asc;", conn))
                        {
                            commandforloadlistequipmentworkerfromdatabase.Parameters.AddWithValue("equipmentName", NpgsqlDbType.Varchar, comboboxforlistequipmentworker.Text.Split('|')[0].Trim());

                            using (var readercommandforloadlistequipmentworkerfromdatabase = commandforloadlistequipmentworkerfromdatabase.ExecuteReader())
                            {
                                while (readercommandforloadlistequipmentworkerfromdatabase.Read())
                                {
                                    comboboxforlistrequiredservice.Items.Add(readercommandforloadlistequipmentworkerfromdatabase.GetString(0));
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
            else if (userPrivilige == "worker by request")
            {
                string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                    {
                        conn.Open();

                        using (var commandforloadlistequipmentworkerfromdatabase = new NpgsqlCommand("select rs.\"Name required service\" from \"List of required services\" rs join \"List of equipment\" e on e.\"ID equipment\" = rs.\"ID equipment\" where e.\"Name equipment\" = @equipmentName order by rs.\"Name required service\" asc;", conn))
                        {
                            commandforloadlistequipmentworkerfromdatabase.Parameters.AddWithValue("equipmentName", NpgsqlDbType.Varchar, comboboxforlistequipmentworker.Text.Split('|')[0].Trim());

                            using (var readercommandforloadlistequipmentworkerfromdatabase = commandforloadlistequipmentworkerfromdatabase.ExecuteReader())
                            {
                                while (readercommandforloadlistequipmentworkerfromdatabase.Read())
                                {
                                    comboboxforlistrequiredservice.Items.Add(readercommandforloadlistequipmentworkerfromdatabase.GetString(0));
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

        internal static bool addnewrequest(string login, string userPrivilige, ComboBox comboboxforlistequipmentworker, ComboBox comboboxforlistrequiredservice, TextBox textboxfordescription)
        {
            if (MessageBox.Show("Вы уверены в том, что вы все правильно указали?", "Система", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (comboboxforlistequipmentworker.SelectedIndex != -1 && comboboxforlistrequiredservice.SelectedIndex != -1 && !string.IsNullOrEmpty(textboxfordescription.Text) && !string.IsNullOrWhiteSpace(textboxfordescription.Text))
                {
                    int? intforinvnumber = null;
                    int? intforidworker = null;

                    if (userPrivilige == "worker")
                    {
                        string connstringforworker = "Host = localhost; Port = 5432; Username = worker; Password = password; Database = DailyPlanner";

                        try
                        {
                            using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworker))
                            {
                                conn.Open();

                                using (var transaction = conn.BeginTransaction())
                                {
                                    try
                                    {
                                        using (var commandforgrab = new NpgsqlCommand("select wpc.\"Inventory number\", wpc.\"ID worker\" from \"List of workers PC\" wpc join \"List of workers accounts\" wa on wa.\"ID worker\" = wpc.\"ID worker\" where wa.\"Login\" = @login;", conn, transaction))
                                        {
                                            commandforgrab.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);

                                            using (var reader = commandforgrab.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {
                                                    intforinvnumber = reader.GetInt32(0);
                                                    intforidworker = reader.GetInt32(1);
                                                }
                                            }
                                        }

                                        using (var commandforlog = new NpgsqlCommand("SELECT set_config('daily_planner.current_user', @workerId, true);", conn, transaction))
                                        {
                                            commandforlog.Parameters.AddWithValue("workerId", NpgsqlDbType.Varchar, Convert.ToString(intforidworker));

                                            commandforlog.ExecuteNonQuery();
                                        }

                                        using (var commandforinsert = new NpgsqlCommand("insert into \"Request\" (\"Inventory number subject\", \"Subject of the application\", \"Required service\", \"Inventory number\", \"Date of request submission\", \"Last modified date\", \"Description request\", \"Request status\") values (@invsubject, @subject, @service, @number, now(), now(), @description, 'Ожидание');", conn, transaction))
                                        {
                                            commandforinsert.Parameters.AddWithValue("invsubject", NpgsqlDbType.Integer, Convert.ToInt32(comboboxforlistequipmentworker.Text.Split('|')[1].Replace(" Инвентарный номер: ", "").Trim()));
                                            commandforinsert.Parameters.AddWithValue("subject", NpgsqlDbType.Varchar, comboboxforlistequipmentworker.Text.Split('|')[0].Trim());
                                            commandforinsert.Parameters.AddWithValue("service", NpgsqlDbType.Varchar, comboboxforlistrequiredservice.Text);
                                            commandforinsert.Parameters.AddWithValue("number", NpgsqlDbType.Integer, intforinvnumber);
                                            commandforinsert.Parameters.AddWithValue("description", NpgsqlDbType.Varchar, textboxfordescription.Text);

                                            commandforinsert.ExecuteNonQuery();
                                        }

                                        transaction.Commit();
                                        return true;
                                    }
                                    catch
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Ошибка соединения с базой данных", "Система");
                                        return false;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка соединения с базой данных", "Система");
                            return false;
                        }
                    }
                    else if (userPrivilige == "worker by request")
                    {
                        string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

                        try
                        {
                            using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                            {
                                conn.Open();

                                using (var transaction = conn.BeginTransaction())
                                {
                                    try
                                    {
                                        using (var commandforgrab = new NpgsqlCommand("select wpc.\"Inventory number\", wpc.\"ID worker\" from \"List of workers PC\" wpc join \"List of workers accounts\" wa on wa.\"ID worker\" = wpc.\"ID worker\" where wa.\"Login\" = @login;", conn, transaction))
                                        {
                                            commandforgrab.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);

                                            using (var reader = commandforgrab.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {
                                                    intforinvnumber = reader.GetInt32(0);
                                                    intforidworker = reader.GetInt32(1);
                                                }
                                            }
                                        }

                                        using (var commandforlog = new NpgsqlCommand("SELECT set_config('daily_planner.current_user', @workerId, true);", conn, transaction))
                                        {
                                            commandforlog.Parameters.AddWithValue("workerId", NpgsqlDbType.Varchar, Convert.ToString(intforidworker));

                                            commandforlog.ExecuteNonQuery();
                                        }

                                        using (var commandforinsert = new NpgsqlCommand("insert into \"Request\" (\"Inventory number subject\", \"Subject of the application\", \"Required service\", \"Inventory number\", \"Date of request submission\", \"Last modified date\", \"Description request\", \"Request status\") values (@invsubject, @subject, @service, @number, now(), now(), @description, 'Ожидание');", conn, transaction))
                                        {
                                            commandforinsert.Parameters.AddWithValue("invsubject", NpgsqlDbType.Integer, Convert.ToInt32(comboboxforlistequipmentworker.Text.Split('|')[1].Replace(" Инвентарный номер: ", "").Trim()));
                                            commandforinsert.Parameters.AddWithValue("subject", NpgsqlDbType.Varchar, comboboxforlistequipmentworker.Text.Split('|')[0].Trim());
                                            commandforinsert.Parameters.AddWithValue("service", NpgsqlDbType.Varchar, comboboxforlistrequiredservice.Text);
                                            commandforinsert.Parameters.AddWithValue("number", NpgsqlDbType.Integer, intforinvnumber);
                                            commandforinsert.Parameters.AddWithValue("description", NpgsqlDbType.Varchar, textboxfordescription.Text);

                                            commandforinsert.ExecuteNonQuery();
                                        }

                                        transaction.Commit();
                                        return true;
                                    }
                                    catch
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Ошибка соединения с базой данных", "Система");
                                        return false;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка соединения с базой данных", "Система");
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные", "Система");
                    return false;
                }               
            }
            else
            {
                return false;
            }
        }
    }
}
