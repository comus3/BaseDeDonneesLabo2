using System.Data;
using MySql.Data.MySqlClient;
namespace carAccessory;
class Program
{

    static void Main(string[] args)
        {
        //Instancier l'objet myDbConn en lui donnant la chaine de connexion
        //myDbConn= new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\bus.accdb");
        MySqlConnection myDbConn = new MySqlConnection(@"server=127.0.0.1;userid=root;pwd=root;persistsecurityinfo=True;database=dvauto;port=3308;sharedmemoryname=");
        //Construiser la chaine de connexion dans VS / Server explorer / Connect to database
        // Ouverture et fermeture de la connexion
        try
        {
            // open connection
            myDbConn.Open();
            // Commande SQL SELECT
            // -------------------
            String myQueryString = "SELECT * FROM tb_fournisseur ";
            // declare oleDbcommand object
            MySqlCommand myCmd = new MySqlCommand(myQueryString, myDbConn);
            /*
            // declare oleDbcommand object Version 2 ;-)
            OleDbCommand myCmd = new OleDbCommand();
            cmd.Connection = myDbConn;
            cmd.CommandText = myQueryString;
            */
            //OleDbDataReader permet de recevoir le résultat d'une requête SELECT
            MySqlDataReader myDbReader = null;
            // execute SQL Command
            myDbReader = myCmd.ExecuteReader();
            /*
            // Show first row first col ([0])
            myDbReader.Read();
            MessageBox.Show(myDbReader[0].ToString());
            // read each record
            while (myDbReader.Read()) // read next line
            {
            // extract data from record
            string ipk_Fourn = myDbReader["pk_Numero_fournisseur"].ToString();
            string nom = myDbReader.GetString(1);
            string adresse = myDbReader.GetString(2);
            // do something with data ...
            }
            */
            // pour plus de souplesse, on peut stocker le dbReader dans une DataTable
            DataTable myDT = new DataTable();
            // save query results in the datatable
            myDT.Load(myDbReader);
            // Show first row, field "Nom"
            //MessageBox.Show(myDT.Rows[0]["Nom"].ToString());
            // If there is a dataGridView on the WinForm :
            /*
            // Commande SQL INSERT
            //--------------------
            myQueryString = "insert into cepage (nom) VALUES ('" + tb_cepage.Text + "')
            ";
            // declare oleDbcommand object
            OleDbCommand myInsertCmd = new OleDbCommand(myQueryString, myDbConn);
            // execute insert command
            int nb_row = myInsertCmd.ExecuteNonQuery();
            if (nb_row == 1)
            MessageBox.Show("Enregistrement réussi ");
            // Même logique pour UPDATE ou DELETE (requêtes SQL sans autre retour que
            le nombre de lignes affectées
            */
        }
        catch (Exception ex)
        {
            //MessageBox.Show("Failed to connect to data source " + ex).ToString();
        }
        finally
        {
            // Disconnect Database
            myDbConn.Close();
        }
    }

}

