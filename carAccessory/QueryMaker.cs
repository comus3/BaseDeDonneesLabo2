using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace carAccessory;

class QueryMaker
{
    private MySqlConnection connection;

    public QueryMaker(MySqlConnection mySqlConnection)
    {
        connection = mySqlConnection;
    }

    public DataTable ExecuteSelectQuery(string selectQuery)
    {
        DataTable dataTable = new DataTable();
        try
        {
            using (MySqlCommand myCmd = new MySqlCommand(selectQuery, connection))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(myCmd))
                {
                    dataAdapter.Fill(dataTable);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing SELECT query: {ex.Message}");
        }

        return dataTable;
    }

    public int ExecuteNonQuery(string nonQuery)
    {
        int rowsAffected = 0;

        try
        {
            using (MySqlCommand myCmd = new MySqlCommand(nonQuery, connection))
            {
                connection.Open();
                rowsAffected = myCmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing non-query: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }

        return rowsAffected;
    }

    public DataTable ReadLorgeMethod(string query)
    {
        MySqlCommand myCmd = new MySqlCommand(query, connection);
            
        MySqlDataReader myDbReader = null;
        // execute SQL Command
        myDbReader = myCmd.ExecuteReader();
        myDbReader.Read();
        while (myDbReader.Read()) // read next line
        {
            // extract data from record
            string ipk_Fourn = myDbReader["pk_Numero_fournisseur"].ToString();
            string nom = myDbReader.GetString(1);
            string adresse = myDbReader.GetString(2);
            // do something with data ...
        }
        // pour plus de souplesse, on peut stocker le dbReader dans une DataTable
        DataTable myDT = new DataTable();
        // save query results in the datatable
        myDT.Load(myDbReader);
        return myDT;

    }
}

