using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BCrypt.Net;
using AdTrafficWebApp.BLL;

namespace AdTrafficWebApp.DAL
{
    
    public class UserDB
    {

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        
        public static bool AuthenticateUser(int userId, string password)
        {
            
            using (SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Password FROM Users WHERE UserId = @UserId";
                cmd.Parameters.AddWithValue("@UserId", userId);
                
                string passwordFromDB=cmd.ExecuteScalar() as string; 
            
                if(passwordFromDB!=null && passwordFromDB.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void RegisterUser(User user) 
        {
            
            SqlConnection conn = UtilityDB.ConnectDB();
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Users (UserId, Password, Email, RoleName, UserName) VALUES (@UserId, @Password, @Email, @RoleName, @UserName)";
            cmd.Parameters.AddWithValue("@UserId", user.UserId);
            cmd.Parameters.AddWithValue("@Password", user.Password); 
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@RoleName", user.RoleName);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);

            cmd.ExecuteNonQuery();

            conn.Close();

                
            
        }
        

        public static User GetUserById(int userId)
        {
            User user = null;

            // Connect to the database
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                // Define the SQL command for selecting the employee by ID
                string selectQuery = "SELECT * FROM Users WHERE UserId = @UserId";

                // Create a SqlCommand object
                using (SqlCommand cmdSelect = new SqlCommand(selectQuery, connDB))
                {
                    // Add the parameter for the employee ID
                    cmdSelect.Parameters.AddWithValue("@UserId", userId);

                    // Execute the query
                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        // Check if a record was found
                        if (reader.Read())
                        {
                            // Create a new User object
                            user = new User();

                            // Set the properties using the public setters
                            user.UserId = Convert.ToInt32(reader["UserId"]);
                            user.Password = reader["Password"].ToString();
                            user.Email = reader["Email"].ToString();
                            user.RoleName = reader["RoleName"].ToString();
                            user.UserName = reader["UserName"].ToString();
                        }
                    }
                }
            }

            return user;
        }


        public static bool IsDublicateId(int checkId)
        {
            User user = new User();
            user = GetUserById(checkId);
            if (user != null)
            {
                return true;
            }


            return false;
        }

    }
}