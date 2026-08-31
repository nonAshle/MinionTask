using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace DailyPlanner.code
{
    internal static class codeforformforviewlog
    {
        internal static void loadlog (int id, RichTextBox whereview)
        {
            string connstringforworkerbyrequest = "Host = localhost; Port = 5432; Username = worker by request; Password = passwordforrequest; Database = DailyPlanner";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstringforworkerbyrequest))
                {
                    conn.Open();

                    using (var loadlog = new NpgsqlCommand("select \"Date change\" || ': ' || \"Log description\"  from \"Activity History\" where \"ID request\" = @id order by \"Date change\" asc", conn))
                    {
                        loadlog.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);

                        using (var reader = loadlog.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                whereview.AppendText(reader.GetString(0) + Environment.NewLine);
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
