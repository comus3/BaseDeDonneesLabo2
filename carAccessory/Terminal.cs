using System;
using System.Data;
namespace carAccessory;

class Terminal
{
    private Dictionary<string, Action> switcher;
    
    public void terminal()
    {
        // Initialisez vos données ici (fournisseurs, articles, etc.)
        switcher = new Dictionary<string, Action>
        {
            { "afficherTabs", AfficherListes },
            { "afficherArticles", AfficherArticles },
            { "afficherArticlesCategories", AfficherArticlesParCategorie },
            { "AfficherArticlesVendusAChampion", AfficherArticlesVendusAChampion },
            { "ArticlesStockes", AfficherFournisseursVolantStockSup5 },
            { "a_calc", AfficherFournisseursMoinsChersParArticle },
            { "b_calc", ListePrixMoyensParProduit },
            {"custom",CustomCommand},
            {"help",Help},
            { "exit", Exit }
        };
    }

        public void SwitchCase(string commande)
    {
        if (switcher.TryGetValue(commande, out var action))
        {
            action();
        }
        else
        {
            Console.WriteLine("Commande invalide");
        }
    }

    static void CustomCommand()
    {
        Console.WriteLine("Calling AfficherListes...");
        Console.Write("entrez vitre query.   ");
        string query = Console.ReadLine();
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }
    static void AfficherListes()
    {
        Console.WriteLine("Calling AfficherListes...");
        string query = "SELECT * FROM dvauto";
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }

    static void AfficherArticles()
    {
        Console.WriteLine("Calling AfficherArticles...");
        string query = "SELECT * FROM dvauto.articles";
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }

    static void AfficherArticlesParCategorie()
    {
        Console.WriteLine("Calling AfficherArticlesParCategorie...");
        string query = "select description_categorie, description_article, pk_num_article, Prix from dvauto.categorie ";
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }

    static void AfficherArticlesVendusAChampion()
    {
        Console.WriteLine("Calling AfficherArticlesVendusAChampion...");
        string query = "select description_Article,Nom from dvauto.nomenclature;Inner Join dvauto.fournisseurs on pk_Numero_fournisseur=fk_num_categorie where fk_num_categorie=5;";
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }

    static void AfficherFournisseursVolantStockSup5()
    {
        Console.WriteLine("Calling AfficherFournisseursVolantStockSup5...");
        string query = "SELECT * FROM dvauto";
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }

    static void AfficherFournisseursMoinsChersParArticle()
    {
        Console.WriteLine("Calling AfficherFournisseursMoinsChersParArticle...");
        string query = "SELECT * FROM dvauto";
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }

    static void ListePrixMoyensParProduit()
    {
        Console.WriteLine("Calling ListePrixMoyensParProduit...");
        string query = "SELECT * FROM dvauto";
        DataTable result = Program.queryMaker.ExecuteSelectQuery(query);
        Displayer.DisplayData(result);
    }
    static void Help()
    {
        Console.WriteLine("Bienvenue dans l'aide de l'application:");
        Console.WriteLine();
        Console.WriteLine("Commandes disponibles :");
        Console.WriteLine(" - afficherTabs : Affiche les onglets (tables) disponibles.");
        Console.WriteLine(" - afficherArticles : Affiche la liste des articles.");
        Console.WriteLine(" - afficherArticlesCategories : Affiche la liste des articles par catégorie.");
        Console.WriteLine(" - AfficherArticlesVendusAChampion : Affiche les articles vendus à Champion.");
        Console.WriteLine(" - ArticlesStockes : Affiche les articles stockés avec plus de 5 pièces.");
        Console.WriteLine(" - a_calc : Affiche les fournisseurs les moins chers pour chaque article.");
        Console.WriteLine(" - b_calc : Affiche la liste des prix moyens pour chaque produit.");
        Console.WriteLine(" - help : Affiche cette aide.");
        Console.WriteLine();
        Console.WriteLine("Utilisez 'exit' pour quitter l'application.");
    }

    private void Exit()
    {
        Environment.Exit(0);
    }

    public void TerminalRunner()
    {
        var app = new Terminal();
        app.terminal();
            while (true)
            {
                Console.Write("Entrez une commande :  ");
                var commande = Console.ReadLine();
                app.SwitchCase(commande);
            }
    }
}