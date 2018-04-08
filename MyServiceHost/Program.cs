using System;
using System.ServiceModel;

namespace MyServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(MathsLibrary.VelibInformationService));
                host.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception timeProblem)
            {
                Console.WriteLine(timeProblem.Message);
                Console.ReadLine();
            }
        }
    }
}
