using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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


    static void AfficherListes()
    {
        Console.WriteLine("Calling AfficherListes...");
        
    }

    static void AfficherArticles()
    {
        Console.WriteLine("Calling AfficherArticles...");
        
    }

    static void AfficherArticlesParCategorie()
    {
        Console.WriteLine("Calling AfficherArticlesParCategorie...");

    }

    static void AfficherArticlesVendusAChampion()
    {
        Console.WriteLine("Calling AfficherArticlesVendusAChampion...");

    }

    static void AfficherFournisseursVolantStockSup5()
    {
        Console.WriteLine("Calling AfficherFournisseursVolantStockSup5...");

    }

    static void AfficherFournisseursMoinsChersParArticle()
    {
        Console.WriteLine("Calling AfficherFournisseursMoinsChersParArticle...");

    }

    static void ListePrixMoyensParProduit()
    {
        Console.WriteLine("Calling ListePrixMoyensParProduit...");
        // Call corresponding method in QueryMaker or implement logic here
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
            while (true)
            {
                Console.Write("Entrez une commande ");
                var commande = Console.ReadLine().ToLower();
                app.SwitchCase(commande);
            }
    }
}