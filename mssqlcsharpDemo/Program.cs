using System;
using System.Data.SqlClient;

namespace SQLdemoCsharp {
    class Program {
        static void Main(string[] args)
        {

            string connetionString = null;
            SqlConnection connection;

            connetionString = "Data Source=cstnt.tstc.edu;Initial Catalog=inew2330fa20;User ID=aborden;Password=password";
            connection = new SqlConnection(connetionString);
            try
            {
                //N00bery has happened here.
                //Love, Dave.
                connection.Open();
                Console.WriteLine("Connection Open ! ");
                while (true)
                {
                    try
                    {
                        string query = "";
                        Console.WriteLine("Enter Query: ");
                        query = Console.ReadLine();
                        if (query == "quit")
                        {
                            Console.WriteLine("Attempting a conflict...");
                            return;
                        }
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                Console.Write(dataReader[i] + "\t");
                            }
                            Console.WriteLine();
                        }
                        dataReader.Close();
                    }
                    catch (SqlException x)
                    {
                        Console.WriteLine(x.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();

        }
    }
}
