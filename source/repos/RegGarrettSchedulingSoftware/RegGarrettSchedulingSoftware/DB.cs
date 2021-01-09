using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace RegGarrettSchedulingSoftware
{
    class DB
    {
        public static string sqlString = "SERVER=wgudb.ucertify.com; DATABASE=U04qSi; Uid=U04qSi; Pwd=53688318875";
        public static bool login(string usr, string pwd)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);

            try
            {
                MySqlCommand verify = new MySqlCommand($"SELECT COUNT(*) FROM user WHERE username='{usr}' AND password='{pwd}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(verify);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else return false;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error logging in: " + x);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private static List<string> formatDates(DateTime start, DateTime end)
        {
            string startDate = start.ToString("yyyy'-'MM'-'dd HH:mm:ss"); 
            string endDate = end.ToString("yyyy'-'MM'-'dd HH:mm:ss");
            List<string> dates = new List<string>{ startDate, endDate };
            return dates;
        }

        public static DataTable getAppts(DateTime start, DateTime end)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                List<string> formattedDates = formatDates(start, end);
                //MySqlCommand getAppt = new MySqlCommand($"SELECT * FROM appointment WHERE start BETWEEN {formattedDates[0]} AND {formattedDates[1]}", conn);
                MySqlCommand getAppt = new MySqlCommand($"SELECT c.customerName, a.type, a.start, a.end, a.appointmentId FROM appointment AS a INNER JOIN customer AS c ON c.customerId = a.customerId AND a.start BETWEEN '{formattedDates[0]}' AND '{formattedDates[1]}'", conn);
                //MySqlCommand getAppt = new MySqlCommand("SELECT * FROM appointment", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppt);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error fetching appointments: " + x);
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
