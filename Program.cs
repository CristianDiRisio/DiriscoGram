using System.ComponentModel.Design;

internal class Program
{
    private static Dictionary<string, string> userDatabase = new Dictionary<string, string>();  // Database per utenti e password
    private static Dictionary<string, List<string>> userFriends = new Dictionary<string, List<string>>(); // Amici per utente
    private static string loggedInUser = null;  // Utente attualmente loggato
    private static List<string> userPost = new List<string>(); // Post per utente
    private static List<string> friendPost = new List<string>(); // Post per amico
    private static List<string> allPost = new List<string>(); // Tutti i post
    private static List<string> allUser = new List<string>(); // Tutti gli utenti


    static void Log()
    {
        Console.Write("Inserisci il tuo username: ");
        string username = Console.ReadLine();
        Console.Write("Inserisci la tua password: ");
        string password = Console.ReadLine();
        if (userDatabase.ContainsKey(username) && userDatabase[username] == password)
        {
            loggedInUser = username;
            Console.WriteLine("Accesso effettuato con successo!");
            int menu;
            do
            {
                Console.WriteLine("1. Aggiungi amico");
                Console.WriteLine("2. Visualizza amici");
                Console.WriteLine("3. Crea un Post");
                Console.WriteLine("4. Visualizza i tuoi Post");
                Console.WriteLine("5. Visualizza i Post dei tuoi amici");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        AddFriend();
                        break;
                    case 2:
                        ShowFriends();
                        break;
                    case 3:
                        AddaPost();
                        break;
                    case 4:
                        ViewYourPost();
                        break;
                    case 5:
                        ViewFriendPost();
                        break;
                    case 0:
                        Console.WriteLine("Disconnessione in corso...");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (menu != 0);
        }
        else
        {
            Console.WriteLine("Username o password errati!");
        }
    }
    static void Register()
    {
        Console.Write("Inserisci il tuo username: ");
        string username = Console.ReadLine();
        Console.Write("Inserisci la tua password: ");
        string password = Console.ReadLine();
        userDatabase.Add(username, password);
        userFriends.Add(username, new List<string>());
        Console.WriteLine("Registrazione completata con successo!");
    }

    static void AddFriend()
    {
        Console.Write("Inserisci l'username dell'amico da aggiungere: ");
        string friend = Console.ReadLine();

        if (friend == loggedInUser)
        {
            Console.WriteLine("Non puoi aggiungere te stesso come amico!");
            return;
        }
        else if (userDatabase.ContainsKey(friend))
        {
            userFriends[loggedInUser].Add(friend);
            Console.WriteLine("Amico aggiunto con successo!");
        }
        else
        {
            Console.WriteLine("Utente non trovato!");
        }
    }

    static void ShowFriends()
    {
        Console.WriteLine("I tuoi amici sono:");
        foreach (string friend in userFriends[loggedInUser])
        {
            Console.WriteLine(friend);
        }
    }

    static void AddaPost()
    {
        Console.Write("Inserisci il tuo post: ");
        string post = Console.ReadLine();
        userPost.Add(post);
        allPost.Add(post);
        Console.WriteLine("Post aggiunto con successo!");
    }

    static void ViewYourPost()
    {
        Console.WriteLine("I tuoi post sono:");
        foreach (string post in userPost)
        {
            Console.WriteLine(post);
        }
    }

    static void ViewFriendPost()
    {
        Console.Write("Inserisci l'username dell'amico di cui vuoi vedere i post: ");
        string friend = Console.ReadLine();
        if (userFriends[loggedInUser].Contains(friend))
        {
            Console.WriteLine("I post di " + friend + " sono:");
            foreach (string post in userPost)
            {
                Console.WriteLine(post);
            }
        }
        else
        {
            Console.WriteLine("Utente non trovato!");
        }

        
    }

    private static void Main(string[] args)
    {
        userDatabase.Add("Admin", "Admin");
        int menu;
        Console.WriteLine("Benvenuto in DiriscoGram!");
        do
        {
            Console.WriteLine("1. Registrati");
            Console.WriteLine("2. Accedi");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
            menu = int.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    Register();
                    break;
                case 2:
                    Log();
                    break;
                case 0:
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (menu != 0);
    }

}


