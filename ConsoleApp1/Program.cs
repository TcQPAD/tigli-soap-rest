using System;
using MathsLibrary;
using Newtonsoft.Json;


namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Client velibs opérationnel.");
            Console.WriteLine("Tapez help pour une liste des commandes disponibles, ou une commande pour lancer l'exécution d'une requête.");
            Console.WriteLine("");

            VelibsAPIRequests client = new VelibsAPIRequests();
            String cityName = "Toulouse"; // default city
            String stationID = "00110"; // default stationID
            String syn = "y";

            //Console.WriteLine(client.GetVelibCounts("Toulouse"));
            while (true)
            {
                Console.Write("> ");
                String accessPoint = Console.ReadLine();

                if (accessPoint == null)
                {
                    Console.WriteLine("Fermeture du client CLI.");
                    break;
                }

                else if (accessPoint.Equals("help"))
                    displayHelp();

                else if (accessPoint.Equals("list"))
                {
                    Console.WriteLine("> Nom de la ville:");
                    cityName = Console.ReadLine();
                    Console.WriteLine("> Synchrone? (y/n)");
                    syn = Console.ReadLine();
                    if (syn.Equals("y"))
                        performListStationRequest(client, cityName, true);
                    else
                        performListStationRequest(client, cityName, false);


                }

                else if (accessPoint.Equals("get"))
                {
                    Console.WriteLine("> Nom de la ville:");
                    cityName = Console.ReadLine();

                    Console.WriteLine("> ID de la station:");
                    stationID = Console.ReadLine();

                    Console.WriteLine("> Synchrone? (y/n)");
                    syn = Console.ReadLine();
                    if (syn.Equals("y"))
                        getVelibsAtStation(client, cityName, stationID, true);
                    else
                        getVelibsAtStation(client, cityName, stationID, false);
                }

                else
                {
                    Console.WriteLine("Fermeture du client CLI.");
                    break;
                }

            }

            Console.ReadLine();

        }

        /**
         * Displays the help for this client CLI
         * 
         */
        private static void displayHelp()
        {
            Console.WriteLine(""); // line jump
            Console.WriteLine("Commandes disponibles : ");
            Console.WriteLine("\tlist  ==>  Liste toutes les stations dans la ville demandée lors de l'éxécution de cette commande.");
            Console.WriteLine("\tget  ==>  Affiche le nombre de vélibs de la station demandée lors de l'éxécution de cette commande.");
            Console.WriteLine("\thelp  ==>  Affiche cette aide.");
        }

        private static void performListStationRequest(VelibsAPIRequests client, String cityName, bool isSyn)
        {
            Station[] json;
            // Deserializes the JSON to manipulate and parse it
            if (isSyn)
                json = JsonConvert.DeserializeObject<Station[]>(client.ListVelibStations(cityName));
            else 
                json = JsonConvert.DeserializeObject<Station[]>(client.AsyncListVelibStations(cityName).Result);

            Console.WriteLine("Liste des stations à " + cityName + " :");

            foreach (Station s in json)
            {
                Console.WriteLine("\tPoint d'accès: " + s.Name);
                //Console.WriteLine("Addresse de la station: " + s.Address);
                //Console.WriteLine("Position GPS : (" + s.Position.Lat + ", " + s.Position.Lng + ")");
                //Console.WriteLine("ID du point d'accès: " + s.Number);
                //Console.WriteLine("Velibs disponibles au point d'accès " + s.Name + " : " + s.Available_Bikes + " vélibs");
            }
        }

        private static void getVelibsAtStation(VelibsAPIRequests client, String cityName, String stationID, bool isSyn)
        {
            Station json;

            // Deserializes the JSON to manipulate and parse it
            if (isSyn)
                json = JsonConvert.DeserializeObject<Station>(client.GetVelibCounts(cityName, stationID));
            else
                json = JsonConvert.DeserializeObject<Station>(client.AsyncGetVelibCounts(cityName, stationID).Result);

            Console.WriteLine("Velibs disponibles au point d'accès " + json.Name + " : " + json.Available_Bikes + " vélibs");
        }
    }
}
