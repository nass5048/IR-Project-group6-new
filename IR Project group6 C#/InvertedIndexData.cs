using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_Project_group6_C_
{
    internal class InvertedIndexData
    {
        public string token;
        public List<string> locations = new List<string>();
        public InvertedIndexData(string token, string locations)
        {
            this.token = token;
            this.locations.Add(locations);
        }
        public void AddLocation(string location)
        {
            locations.Add(location);
        }
    }
}
