using System;
using System.Data;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AnConsole
{
	public class DB
	{


            public static MySqlConnection GetConnection()
            {
                string server = "datasource=localhost;port=3306;username=root;password=samidsamid;database=petDB;";
                MySqlConnection connec = new MySqlConnection(server);
                try
                {
                    connec.Open();

                }
                catch (Exception ex)
                {

                }
                return connec;
            }
            public static void AddPet(Pet pet)
            {
                MySqlConnection connec = GetConnection();

                string sql = "INSERT INTO Pets_Table(petID,NickName,Species,Age,physicalDescription,personalDescription) VALUES (@param1,@param2,@param3,@param4,@param5,@param6)";
                MySqlCommand cmd = new MySqlCommand(sql, connec);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@param1", null);
                cmd.Parameters.AddWithValue("@param2", pet.NickName);
                cmd.Parameters.AddWithValue("@param3", pet.Species);
                cmd.Parameters.AddWithValue("@param4", pet.Age);
                cmd.Parameters.AddWithValue("@param5", pet.Physic);
                cmd.Parameters.AddWithValue("@param6", pet.Personal);
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Your information have been registered with successfully!! ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                connec.Close();
            }
            public static void getPet(string nickName)
           

        {
            MySqlConnection connect = GetConnection();

            try
            {

                string query = "SELECT * FROM Pets_Table Where NickName=@parameter";
                MySqlCommand command = new MySqlCommand(query, connect);
                command.Parameters.AddWithValue("@parameter", nickName);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Assuming you have columns named "column1" and "column2"
                        string column1Value = reader["NickName"].ToString();
                        string column2Value = reader["Species"].ToString();
                        string column3Value = reader["Age"].ToString();
                        string column4Value = reader["physicalDescription"].ToString();

                        Console.WriteLine($"NickName: {column1Value}, Species: {column2Value}, Age: {column3Value}, Physical Description: {column4Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sorry, This Pet is not registered {ex.Message}");
            }
        }
        public static void getCats(string specie)
        {
            MySqlConnection connect = GetConnection();
            try
            {
                string query = "SELECT * from Pets_Table WHERE Species=@parameter";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@parameter", specie);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string column1Value = reader["NickName"].ToString();
                        string column2Value = reader["Species"].ToString();
                        string column3Value = reader["Age"].ToString();
                        string column4Value = reader["physicalDescription"].ToString();

                        Console.WriteLine($"NickName: {column1Value}, Species: {column2Value}, Age: {column3Value}, Physical Description: {column4Value}");
                    }
                }

            }catch(Exception ex)
            {

            }
        }
            public static void GetAll()
        {
            MySqlConnection connect = GetConnection();
            try
            {

                string query = "SELECT * FROM Pets_Table";
                MySqlCommand command = new MySqlCommand(query, connect);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Assuming you have columns named "column1" and "column2"
                        string column1Value = reader["NickName"].ToString();
                        string column2Value = reader["Species"].ToString();
                        string column3Value = reader["Age"].ToString();
                        string column4Value = reader["physicalDescription"].ToString();

                        Console.WriteLine($"NickName: {column1Value}, Species: {column2Value}, Age: {column3Value}, Physical Description: {column4Value}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failure", ex);
            }

            }
        }
    }

