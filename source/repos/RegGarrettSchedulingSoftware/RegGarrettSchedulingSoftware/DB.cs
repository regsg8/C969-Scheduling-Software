using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace RegGarrettSchedulingSoftware
{
    class DB
    {
        public static string sqlString = "SERVER=wgudb.ucertify.com; DATABASE=U04qSi; Uid=U04qSi; Pwd=53688318875";
        public static DataTable table = new DataTable();
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

        public static void getAppts(string start, string end)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            try
            {
                //MySqlCommand getAppt = new MySqlCommand($"SELECT * FROM appointment WHERE start BETWEEN {start} AND {end}", conn);
                MySqlCommand getAppt = new MySqlCommand("SELECT * FROM appoinment");
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppt);
                sda.Fill(table);
            }
            catch (Exception x)
            {
                Console.WriteLine("Error fetching appointments: " + x);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
