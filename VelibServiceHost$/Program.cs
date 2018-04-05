using System;

namespace VelibServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MathsLibrary.VelibInformationService));
            host.Open();
            host.Close();
        }
    }
}
