using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
        class Station
        {
            private string number; // the id of the station
            private string name; // the name of the station
            private string available_bikes; // the number of bikes in the station
            private string address; // the address of the station
            private Location position; // the position of the station, as a tuple (x, y)

            public string Number
            {
                get { return number; }
                set { number = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Available_Bikes
            {
                get { return available_bikes; }
                set { available_bikes = value; }
            }

            public string Address
            {
                get { return address; }
                set { address = value; }
            }

            public Location Position
            {
                get { return position; }
                set { position = value; }
            }

            public override string ToString()
            {
                return "{number: " + number + ", name: " + name + ", available_bikes: " + available_bikes + "}";
            }
    }

}
