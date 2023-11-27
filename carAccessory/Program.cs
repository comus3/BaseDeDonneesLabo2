using System.Data;
using MySql.Data.MySqlClient;
namespace carAccessory;
class Program
{
    public static QueryMaker queryMaker;
    static void Main(string[] args)
    {
        //Instancier l'objet myDbConn en lui donnant la chaine de connexion
        //myDbConn= new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\bus.accdb");
        MySqlConnection myDbConn = new MySqlConnection(@"server=127.0.0.1;userid=root;pwd=241580e5d30;persistsecurityinfo=True;database=dvauto;port=3308;sharedmemoryname=");
        //Construiser la chaine de connexion dans VS / Server explorer / Connect to database
        // Ouverture et fermeture de la connexion
        try
        {
            // open connection
            myDbConn.Open();
            // Commande SQL SELECT
            // -------------------
            queryMaker = new QueryMaker(myDbConn);

            Terminal ui = new Terminal();
            ui.TerminalRunner();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");        
        }
        finally
        {
            // Disconnect Database
            myDbConn.Close();
        }
    }
}

