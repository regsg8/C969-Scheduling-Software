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
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        //Uses lambda to format any number of DateTime items into MySql format and returns them in a list of strings
        private static List<string> formatDates(List<DateTime> dates)
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

        //Returns all appointments between given date range
        public static DataTable getAppts(List<DateTime> dates)
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                List<string> formattedDates = formatDates(dates);
                MySqlCommand getAppt = new MySqlCommand($"SELECT c.customerId, c.customerName, a.type, a.start, a.end, a.appointmentId FROM appointment AS a INNER JOIN customer AS c ON c.customerId = a.customerId AND a.start BETWEEN '{formattedDates[0]}' AND '{formattedDates[1]}'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getAppt);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error fetching appointments: " + x.Message);
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
            }
        }

        //Gets all customers for customer management
        public static DataTable getCustomers()
        {
            MySqlConnection conn = new MySqlConnection(sqlString);
            conn.Open();
            try
            {
                MySqlCommand getCust = new MySqlCommand("SELECT c.customerId, c.customerName, a.phone, a.address, ci.city, co.country FROM customer AS c INNER JOIN address AS a ON c.addressId = a.addressId INNER JOIN city AS ci ON a.cityId = ci.cityId INNER JOIN country AS co ON ci.countryId = co.countryId", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(getCust);
                DataTable data = new DataTable();
                sda.Fill(data);
                return data;
            }
            catch (Exception x)
            {
                Console.WriteLine("Error fetching customers: " + x.Message);
                DataTable noData = new DataTable();
                return noData;
            }
            finally
            {
                conn.Close();
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
                Console.WriteLine("Error fetching customer: " + x.Message);
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
            //check if address needs to update, check for string "no change"
            //if "no change" is not present on any item, then add a string to update that field

            //
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
                    //check
                    MessageBox.Show("Inserted country Id: " + insertCountry.LastInsertedId.ToString());
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
                    //check
                    MessageBox.Show("Inserted city Id: " + insertCity.LastInsertedId.ToString());
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
                //check
                MessageBox.Show("Inserted address Id: " + insertAddress.LastInsertedId.ToString());
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

        public static void addNewCustomer(string name, string phone, string address, string city, string country, string zip)
        {
            List<DateTime> now = new List<DateTime> { DateTime.Now };
            List<string> sqlDate = formatDates(now);
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
    }
}
