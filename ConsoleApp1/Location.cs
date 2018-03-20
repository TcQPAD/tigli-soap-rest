using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Location
    {
        private string lat;
        private string lng;

        public string Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        public string Lng
        {
            get { return lng; }
            set { lng = value; }
        }
    }
}
