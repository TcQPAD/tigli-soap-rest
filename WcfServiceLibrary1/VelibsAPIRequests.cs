using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace MathsLibrary
{
    public class VelibsAPIRequests : IVelibsAPIRequests
    {

        String apiKey = "0007275c2ad52af011055df3b437b5ebed4bbf9f";
        String contract = "Toulouse"; // defaults to Toulouse
        String stationID = "00110";
        
        public async Task<string> AsyncGetVelibCounts(String cityName, String stationID)
        {
            Task<string> req = AsyncPerformRequest("https://api.jcdecaux.com/vls/v1/stations/" + stationID + "?contract=" + cityName + "&apiKey=" + apiKey);
            string result = await req;

            return result;
        }

        public async Task<string> AsyncListVelibStations(String cityName)
        {
            Task<string> req = AsyncPerformRequest("https://api.jcdecaux.com/vls/v1/stations?contract=" + cityName + "&apiKey=" + apiKey);
            string result = await req;

            return result;
        }

        public string GetVelibCounts(String cityName, String stationID)
        {  
            if (stationID != null && (!stationID.Equals("")) && cityName != null && (!cityName.Equals("")))
                return performRequest("https://api.jcdecaux.com/vls/v1/stations/" + stationID + "?contract=" + cityName + "&apiKey=" + apiKey);

            // default call if the user provides no station
            return performRequest("https://api.jcdecaux.com/vls/v1/stations/" + stationID + "?contract=" + contract + "&apiKey=" + apiKey);
        }

        public string ListVelibStations(String city)
        {
            if (city != null && (!city.Equals("")))
                return performRequest("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=" + apiKey);

            // default call if the user provides no station
            return performRequest("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=" + apiKey);
        }

        /**
         * Utility method that will be used by the public functionalities of this SOAP API class contract
         * to perform web requests
         * 
         */
        private string performRequest(String reqUrl)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(
                reqUrl);
            // If required by the server, set the credentials.
            // request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // if the request was successful
            if (((HttpWebResponse)response).StatusDescription.Equals("OK"))
            {
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();

                response.Close();

                return responseFromServer;
            }
            else
            {
                return "error";
            }
        }

        /**
         * Asynchronous version of the web request
         */ 
        private Task<string> AsyncPerformRequest(String reqUrl)
        {
            return Task<string>.Run(() =>
            {
                return performRequest(reqUrl);
            });
        }
    }
}
