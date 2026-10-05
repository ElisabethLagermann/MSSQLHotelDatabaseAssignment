using HotelConsoleApp.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HotelConsoleApp
{
    public class HotelDBConnection
    {
        //instansfelt

        SqlConnection _connection;

        public HotelDBConnection()
        {

        }


        //Method to connect to Database
        public void ConnectToDatabase()
        {
            //Connection string

            var config = new ConfigurationBuilder()

                .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
                .Build();


            string _connectionString = config["ElisabethsSecretString"];


            //Create connection

            _connection = new SqlConnection(_connectionString);

            _connection.Open();

        }

        //Method to disconnect from Database

        public void DisconnectFromDatabase()
        {
            _connection.Close();
        }
    

    //CRUD methods

    //Create method

    public Customer Create(Customer customer)
        {

            ConnectToDatabase();


            string sql = "INSERT INTO Customer (Name, Phone)" +
                    "VALUES (@name, @phone)";


            SqlCommand command = new SqlCommand(sql, _connection);

           
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Phone", customer.Phone);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                throw new ArgumentException("Error. No rows were affected, because no new customer were created.");
            }

            DisconnectFromDatabase();

            return customer;
        }


        public List<Customer> ReadAll()
            {

            List<Customer> list = new List<Customer>();


            ConnectToDatabase();

            string sql = "SELECT * FROM Customer";

           SqlCommand command = new SqlCommand(sql, _connection);

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int id = (int)reader["Id"];
                string name = (string)reader["Name"];
                string phone = (string)reader["Phone"];


                list.Add(new Customer(id, name, phone));
            }

            DisconnectFromDatabase();

            return list;
        }

        public Customer ReadById(int id)
        {

            ConnectToDatabase();

            string sql = "SELECT * FROM Customer " +
                "WHERE Id = @id";

            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@Id", id);


            SqlDataReader reader = command.ExecuteReader();

            Customer customerFound = null;

            if (reader.Read())
            {

                int databaseId = (int)reader["Id"];
                string name = (string)reader["Name"];
                string phone = (string)reader["Phone"];


              customerFound = new Customer(databaseId, name, phone);
            }


            else
            {
                DisconnectFromDatabase();

                throw new KeyNotFoundException("A customer with this Id does not exist");
            }

            DisconnectFromDatabase();

                return customerFound;

        }


        public Customer Update(int id, Customer updatedCustomer)
        {
           
            Customer customerToUpdate = ReadById(id);

            ConnectToDatabase();


            string sql = "UPDATE Customer " +
                "SET name = @Name, phone = @Phone " +
                "WHERE Id=@id";

           
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", updatedCustomer.Name);
            command.Parameters.AddWithValue("@Phone", updatedCustomer.Phone );


            int rowsAffected = command.ExecuteNonQuery();

            DisconnectFromDatabase();

            if (rowsAffected == 1)
            {

            return customerToUpdate;
            }


           

                throw new ArgumentException("Error. No rows were affected, because no new customer were created.");
       

        }
                

           
    }
}

