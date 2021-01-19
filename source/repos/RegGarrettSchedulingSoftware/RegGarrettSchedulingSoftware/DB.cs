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
        private static string server = "wgudb.ucertify.com";
        private static string db = "U04qSi";
        private static string dbPwd = "53688318875";
        public static string sqlString = $"SERVER={server}; DATABASE={db}; Uid={db}; Pwd={dbPwd}";

        //Logs user in
        public static string login(string usr, string pwd)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand verify = new MySqlCommand($"SELECT userId FROM user WHERE username='{usr}' AND password='{pwd}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(verify);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string id = dt.Rows[0][0].ToString();
                if (id != "0")
                {
                    return id;
                }
                else return "";
            }
            catch (Exception x)
            {
                Console.WriteLine("Error logging in: " + x.Message);
                MessageBox.Show("Error logging in.");
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        

        //---Appointment CRUD---//
        //Returns all appointments between given date range
        public static DataTable getAppts(List<DateTime> dates)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                List<string> formattedDates = formatDates(dates);
                MySqlCommand getAppt = new MySqlCommand($"SELECT c.customerId, c.customerName, a.type, a.start, a.end, a.appointmentId FROM appointment AS a INNER JOIN customer AS c ON c.customerId = a.customerId AND a.start BETWEEN '{formattedDates[0]}' AND '{formattedDates[1]}' ORDER BY a.start, a.end, a.customerId", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppt);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting appointments: " + x.Message);
                MessageBox.Show("Error getting appointments.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Adds a new appointment
        public static void newAppointment(int consultantId, int customerId, string type, List<string> dates)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand addAppt = new MySqlCommand($"INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{customerId}', '{consultantId}', 'not needed', 'not needed', 'not needed', 'not needed', '{type}', 'not needed', '{dates[0]}', '{dates[1]}', '{dates[2]}', '{Dashboard.userName}', '{dates[2]}', '{Dashboard.userName}')", conn);
                addAppt.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error adding appointment: " + x.Message);
                MessageBox.Show("Error adding appointment.");
            }
            finally
            {
                conn.Close();
            }
        }

        //Deletes an appointment by id
        public static void deleteAppointment(int id) 
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand deleteAppt = new MySqlCommand($"DELETE FROM appointment WHERE appointmentId = '{id}'", conn);
                deleteAppt.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error deleting appointment: " + x.Message);
                MessageBox.Show("Error deleting appointment.");
            }
            finally
            {
                conn.Close();
            }
        }

        //Gets one appointment by id
        public static DataTable getOneAppointment(int id)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getAppt = new MySqlCommand($"SELECT customerId, type, start, end, userId FROM appointment WHERE appointmentId = '{id}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppt);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting appointment: " + x.Message);
                MessageBox.Show("Error getting appointment.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Updates one appointment by id
        public static void updateAppointment(int apptId, int consultantId, int custId, string type, List<string> dates)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand updateAppt = new MySqlCommand($"UPDATE appointment SET customerId = '{custId}', userId = '{consultantId}', type = '{type}', start = '{dates[0]}', end = '{dates[1]}', lastUpdateBy = '{Dashboard.userName}', lastUpdate = '{dates[2]}' WHERE appointmentId = '{apptId}'", conn);
                updateAppt.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error updating appointment: " + x.Message);
                MessageBox.Show("Error updating appointment.");
            }
            finally
            {
                conn.Close();
            }
        }


        //---Customer CRUD---//
        //Gets all customers
        public static DataTable getCustomers()
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getCust = new MySqlCommand("SELECT c.customerId, c.customerName, a.phone, a.address, ci.city, co.country FROM customer AS c INNER JOIN address AS a ON c.addressId = a.addressId INNER JOIN city AS ci ON a.cityId = ci.cityId INNER JOIN country AS co ON ci.countryId = co.countryId ORDER BY c.customerId, c.customerName", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getCust);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting customers: " + x.Message);
                MessageBox.Show("Error getting customers.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void addNewCustomer(string name, string phone, string address, string city, string country, string zip)
        {
            List<DateTime> nowUtc = new List<DateTime> { TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) };
            List<string> sqlDate = formatDates(nowUtc);
            try
            {
                //Check if country is in db, if not insert new country, return countryId
                int countryId = getCountryId(country);
                if (countryId == 0) throw new Exception("No Country ID");

                //Check if city is in db, if not insert new city with countryId, return cityId
                int cityId = getCityId(city, countryId);
                if (cityId == 0) throw new Exception("No City ID");

                //Insert new address with cityId, phone, and zip, return addressId
                int addressId = getAddressId(address, phone, cityId, zip);
                if (addressId == 0) throw new Exception("No address Id");

                //Insert new customer with name and addressId
                MySqlConnection conn = new MySqlConnection(sqlString);
                conn.Open();
                MySqlCommand insertCust = new MySqlCommand($"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{name}', '{addressId}', '1', '{sqlDate[0]}', '{Dashboard.userName}', '{sqlDate[0]}', '{Dashboard.userName}')", conn);
                insertCust.ExecuteNonQuery();
                MessageBox.Show($"{name} added!");
            }
            catch (Exception x)
            {
                Console.WriteLine("Error adding new customer: " + x.Message);
                MessageBox.Show($"Error encountered, {name} not added.");
            }
        }
        //Gets one customer by id
        public static DataTable getOneCustomer(int id)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getCust = new MySqlCommand($"SELECT c.customerName, a.phone, a.address, ci.city, co.country, a.postalCode FROM customer AS c INNER JOIN address AS a ON c.addressId = a.addressId INNER JOIN city AS ci ON a.cityId = ci.cityId INNER JOIN country AS co ON ci.countryId = co.countryId AND c.customerId = {id}", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getCust);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting customer: " + x.Message);
                MessageBox.Show("Error getting customer.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Updates one customer by id
        public static void updateCustomer(int id, string name, string phone, string address, string city, string country, string zip)
        {
            int countryId = getCountryId(country);
            int cityId = getCityId(city, countryId);
            int addressId = getAddressId(address, phone, cityId, zip);
            List<DateTime> nowUtc = new List<DateTime> { TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) };
            List<string> sqlDate = formatDates(nowUtc);
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand updateCust = new MySqlCommand($"UPDATE customer SET customerName = '{name}', addressId = '{addressId}', lastUpdateBy = '{Dashboard.userName}', lastUpdate = '{sqlDate[0]}' WHERE customerId = '{id}'", conn);
                updateCust.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error updating customer: " + x.Message);
                MessageBox.Show("Error updating customer.");
            }
            finally
            {
                conn.Close();
            }
        }

        //Deletes one customer by id
        public static void deleteCustomer(int id)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand deleteCust = new MySqlCommand($"DELETE FROM customer WHERE customerId = '{id}'", conn);
                deleteCust.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error deleting customer: " + x.Message);
                MessageBox.Show("Error deleting customer.");
            }
            finally
            {
                conn.Close();
            }
        }


        //---REPORTING---//
        //Get all consultants
        public static DataTable getConsultants()
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getCons = new MySqlCommand($"SELECT userId, userName FROM user ORDER BY userName", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getCons);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting consultants: " + x.Message);
                MessageBox.Show("Error getting consultants.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Get all consultant's appointments
        public static DataTable getConsultantAppts(int id)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getAppts = new MySqlCommand($"SELECT c.customerName, a.type, a.start, a.end FROM appointment AS a INNER JOIN customer AS c ON c.customerId = a.customerId AND a.userId = '{id}' ORDER BY a.start, a.end, c.customerName", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppts);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting consultant's appointments: " + x.Message);
                MessageBox.Show("Error getting consultant's appointments.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Get all customer's appointments
        public static DataTable getCustomerAppts(int id)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getAppts = new MySqlCommand($"SELECT c.customerName, a.type, a.start, a.end FROM appointment AS a INNER JOIN customer AS c ON c.customerId = a.customerId AND a.customerId = '{id}' ORDER BY a.start, a.end, c.customerName", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppts);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting customer's appointments: " + x.Message);
                MessageBox.Show("Error getting customer's appointments.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Get all appointment Types
        public static DataTable getApptTypes()
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getTypes = new MySqlCommand("SELECT DISTINCT type FROM appointment", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getTypes);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting appointment types: " + x.Message);
                MessageBox.Show("Error getting appointment types.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Get appointments by type in date range
        public static DataTable getTypeAppts(string type, List<DateTime> dates)
        {
            List<string> formattedDates = formatDates(dates);
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getAppts = new MySqlCommand($"SELECT c.customerName, a.type, a.start, a.end FROM appointment AS a INNER JOIN customer AS c ON c.customerId = a.customerId AND a.type = '{type}' AND a.start BETWEEN '{formattedDates[0]}' AND '{formattedDates[1]}' ORDER BY a.start, a.end, c.customerName", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppts);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting appointments by type: " + x.Message);
                MessageBox.Show("Error getting appointments by type.");
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }


        //---HELPERS---//
        //Uses lambda to format any number of DateTime items into MySql format and returns them in a list of strings
        public static List<string> formatDates(List<DateTime> dates)
        {
            List<string> formatted = new List<string>();
            dates.ForEach(d =>
            {
                string s = d.ToString("yyyy'-'MM'-'dd HH:mm:ss");
                formatted.Add(s);
            }
            );
            return formatted;
        }

        //Check if country is in db, if not insert new country, return countryId
        private static int getCountryId(string country)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            List<DateTime> now = new List<DateTime> { DateTime.Now };
            List<string> sqlDate = formatDates(now);
            try
            {
                int countryId;
                MySqlCommand checkCountry = new MySqlCommand($"SELECT countryId FROM country WHERE country = '{country}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(checkCountry);
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count != 1)
                {
                    MySqlCommand insertCountry = new MySqlCommand($"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{country}', '{sqlDate[0]}', '{Dashboard.userName}', '{sqlDate[0]}', '{Dashboard.userName}')", conn);
                    insertCountry.ExecuteNonQuery();
                    countryId = int.Parse(insertCountry.LastInsertedId.ToString());
                    return countryId;
                }
                else
                {
                    countryId = int.Parse(data.Rows[0][0].ToString());
                    return countryId;
                }

            }
            catch (Exception x)
            {
                Console.WriteLine("Error with Country ID: " + x.Message);
                int nothing = 0;
                return nothing;
            }
            finally
            {
                conn.Close();
            }
        }

        //Check if city is in db, if not insert new city, return cityId
        private static int getCityId(string city, int countryId)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            List<DateTime> now = new List<DateTime> { DateTime.Now };
            List<string> sqlDate = formatDates(now);
            try
            {
                int cityId;
                MySqlCommand checkCity = new MySqlCommand($"SELECT cityId FROM city WHERE city = '{city}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(checkCity);
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count != 1)
                {
                    MySqlCommand insertCity = new MySqlCommand($"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{city}', '{countryId}', '{sqlDate[0]}', '{Dashboard.userName}', '{sqlDate[0]}', '{Dashboard.userName}')", conn);
                    insertCity.ExecuteNonQuery();
                    cityId = int.Parse(insertCity.LastInsertedId.ToString());
                    return cityId;
                }
                else
                {
                    cityId = int.Parse(data.Rows[0][0].ToString());
                    return cityId;
                }

            }
            catch (Exception x)
            {
                Console.WriteLine("Error with City ID: " + x.Message);
                int nothing = 0;
                return nothing;
            }
            finally
            {
                conn.Close();
            }
        }

        //Insert new address with cityId, phone, and zip, return addressId
        private static int getAddressId(string address, string phone, int cityId, string zip)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            List<DateTime> now = new List<DateTime> { DateTime.Now };
            List<string> sqlDate = formatDates(now);
            try
            {
                int addressId;
                MySqlCommand insertAddress = new MySqlCommand($"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES ('{address}', 'not needed', '{cityId}', '{zip}', '{phone}', '{sqlDate[0]}', '{Dashboard.userName}', '{sqlDate[0]}', '{Dashboard.userName}')", conn);
                insertAddress.ExecuteNonQuery();
                addressId = int.Parse(insertAddress.LastInsertedId.ToString());
                return addressId;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error with Address ID: " + x.Message);
                int nothing = 0;
                return nothing;
            }
            finally
            {
                conn.Close();
            }
        }

        //Checks for overlapping appointments for new appointments
        public static bool checkOverlapping(List<string> dates)
        {
            bool overlapping = true;
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getAppts = new MySqlCommand($"SELECT appointmentId FROM appointment WHERE start BETWEEN '{dates[0]}' AND '{dates[1]}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppts);
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count == 0)
                {
                    overlapping = false;
                }
                return overlapping;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting overlapping appointments: " + x.Message);
                return overlapping;
            }
            finally
            {
                conn.Close();
            }
        }
        //Checks for overlapping appointments for updating appointments
        public static bool checkOverlapping(List<string> dates, int apptId)
        {
            bool overlapping = true;
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getAppts = new MySqlCommand($"SELECT appointmentId FROM appointment WHERE start BETWEEN '{dates[0]}' AND '{dates[1]}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppts);
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count != 0)
                {
                    //loop over to check for apptId, remove row if so
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if(int.Parse(data.Rows[i][0].ToString()) == apptId)
                        {
                            data.Rows.RemoveAt(i);
                        }
                    }
                }
                if (data.Rows.Count == 0)
                {
                    overlapping = false;
                }
                return overlapping;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error getting overlapping appointments: " + x.Message);
                return overlapping;
            }
            finally
            {
                conn.Close();
            }
        }

        //Checks for appointments within local business hours
        public static bool insideBusinessHours(List<string> dates)
        {
            bool startInsideHours = false;
            bool endInsideHours = false;
            bool insideHours = false;
            DateTime start = Convert.ToDateTime(dates[0]);
            DateTime end = Convert.ToDateTime(dates[1]);
            DateTime apptStart = TimeZoneInfo.ConvertTimeFromUtc(start, Dashboard.timeZone);
            DateTime apptEnd = TimeZoneInfo.ConvertTimeFromUtc(end, Dashboard.timeZone);
            DateTime now = DateTime.Now;
            DateTime startBusiness = new DateTime(now.Year, now.Month, now.Day, 08, 00, 00);
            DateTime endBusiness = new DateTime(now.Year, now.Month, now.Day, 17, 00, 00);
            if (apptStart.Hour >= startBusiness.Hour && apptStart.Hour <= endBusiness.Hour) startInsideHours = true;
            if (apptEnd.Hour >= startBusiness.Hour && apptStart.Hour <= endBusiness.Hour) endInsideHours = true;
            if (startInsideHours && endInsideHours) insideHours = true;
            return insideHours;
        }
        
    }
}
