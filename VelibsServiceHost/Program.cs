using System;
using System.ServiceModel;

namespace VelibServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MathsLibrary.VelibInformationService));
            host.Open();
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.ReadLine();
            host.Close();
        }
    }
}
