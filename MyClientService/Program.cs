using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyClientService
{
    class Program
    {
        static void Main(string[] args)
        {
            VelibServiceCallbackSink objsink = new VelibServiceCallbackSink();

            InstanceContext iCntxt = new InstanceContext(objsink);

            // Create an object of the service proxy.
            ServiceReference1.VelibInformationServiceClient objClient = new ServiceReference1.VelibInformationServiceClient(iCntxt);

            objClient.numberBikesChanged("Toulouse", "00110", 1000);
            objClient.numberBikesChanged("Toulouse", "00110", 3000);
            objClient.numberBikesChanged("Toulouse", "00110", 2500);
        }
    }
}
