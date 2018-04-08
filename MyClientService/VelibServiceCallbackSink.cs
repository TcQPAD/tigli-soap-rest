using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClientService
{
    internal class VelibServiceCallbackSink : ServiceReference1.IVelibInformationServiceCallback
    {
        public void Calculated(int nOp, double dblNum1, double dblNum2, double dblResult)
        {
            throw new NotImplementedException();
        }

        public void CalculationFinished()
        {
            throw new NotImplementedException();
        }

        public void numberBikesChanged(String city, String station, int nbBikes)
        {
            Console.WriteLine("The number of bikes in the station " + station + " in " + city + " changed!\nRemaining bikes : " + nbBikes);
        }
    }
}
