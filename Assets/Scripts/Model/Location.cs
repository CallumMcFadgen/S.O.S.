using System.Collections.Generic;
using UnityEngine;


namespace SOS
{
    public class Location
    {

        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string _name;                                           // Location name (scene name)
        public string name { get => _name; set => _name = value; }

        private  static Dictionary<string, string> _description = new Dictionary<string, string>();              // Location descriptions
        public Dictionary<string, string> description { get => _description; set => _description = value; }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Location()           // constructor
        {
            LoadLocationText();
        }

        public void LoadLocationText()          // load descriptions with scene discription text 
        {
            Debug.Log("LoadLocationText call");

            description.Add("Beach", "The beach is wide and wind-swept with no signs of any people. The dunes turn into thick Mangroves, but it looks like there is a faint track leading into the trees to the east.");
            description.Add("", "");

            Debug.Log("LoadLocationText success");
        }


    }
}