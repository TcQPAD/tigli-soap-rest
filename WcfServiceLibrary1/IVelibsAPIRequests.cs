using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MathsLibrary
{
    [ServiceContract]
    public interface IVelibsAPIRequests
    {
        [OperationContract]
        string ListVelibStations(String city);

        [OperationContract]
        string GetVelibCounts(String cityName, String stationID);
    }
}
