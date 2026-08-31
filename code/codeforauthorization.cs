using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DailyPlanner.code
{
    internal static class codeforauthorization
    {
        internal static void methodforbuttonauthorization(string login, string password, Form form)
        {
            if (MessageBox.Show("Вы уверены в том, что вы все правильно ввели?", "Система", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (login.Length <= 25 && password.Length <= 30 && login.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch)) == false && password.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch)) == false && login != "" && password != "")
                {
                    try
                    {
                        string stringforgrabresultquerethedatabase = null;
                        string connString = $"Host = localhost; Port = 5432; Username = postgres; Password = qwerty; Database = DailyPlanner"; //5432 5432
                        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                        {
                            conn.Open();

                            using (var commandwhichquerythedatabasetocheckifanaccountexistsfortheuserindatabase = new NpgsqlCommand("select \"Group privilege\" from \"List of workers accounts\" where \"Login\" = @login and \"Password\" = @password;", conn))
                            {
                                commandwhichquerythedatabasetocheckifanaccountexistsfortheuserindatabase.Parameters.AddWithValue("login", NpgsqlDbType.Varchar, login);
                                commandwhichquerythedatabasetocheckifanaccountexistsfortheuserindatabase.Parameters.AddWithValue("password", NpgsqlDbType.Varchar, password);
                                
                                using (var readerforcommandwhichquerythedatabasetocheckifanaccountexistsfortheuserindatabase = commandwhichquerythedatabasetocheckifanaccountexistsfortheuserindatabase.ExecuteReader())
                                {
                                    if (readerforcommandwhichquerythedatabasetocheckifanaccountexistsfortheuserindatabase.Read())
                                    {
                                        stringforgrabresultquerethedatabase = readerforcommandwhichquerythedatabasetocheckifanaccountexistsfortheuserindatabase.GetString(0);
                                    }
                                }
                            }
                        }
                        if (stringforgrabresultquerethedatabase != null)
                        {
                            if (stringforgrabresultquerethedatabase == "worker")
                            {
                                using (formforworker templateforformforworker = new formforworker(login, stringforgrabresultquerethedatabase))
                                {
                                    form.Hide();
                                    templateforformforworker.ShowDialog();
                                }
                                form.Show();
                            }
                            if ((stringforgrabresultquerethedatabase == "worker by request"))
                            {
                                using (formforworker templateforformforworker = new formforworker(login, stringforgrabresultquerethedatabase))
                                {
                                    form.Hide();
                                    templateforformforworker.ShowDialog();
                                }
                                form.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы неверно ввели данные", "Система");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка соединения с базой данных", "Система");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте веденные данные на специальные символы или на количество символов", "Система");
                }
            }
        }
    }
}