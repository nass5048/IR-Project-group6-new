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
        public List<int> locations = new List<int>();
        public InvertedIndexData(string token, int locations)
        {
            this.token = token;
            this.locations.Add(locations);
        }
        public void AddLocation(int location)
        {
            locations.Add(location);
        }
    }
}
