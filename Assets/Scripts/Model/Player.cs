using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOS
{
    public class Player
    {
        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static int _health;                                          // Players health
        public int health { get => _health; set => _health = value; }  
        

        private static int _eventState;                                                     // Players event state (tracks event conditions)
        public int eventState { get => _eventState; set => _eventState = value; }


        private static string _currentLocation;                                                          // Players location (current scene name)    
        public string currentLocation { get => _currentLocation; set => _currentLocation = value; }

        private static List<string> _inventory = new List<string>();                             // Players inventory
        public List<string> inventory { get => _inventory; set => _inventory = value; }


        private static List<string> _eventLog = new List<string>();                           // Players event log
        public List<string> eventLog { get => _eventLog; set => _eventLog = value; }


        private static bool _locationAddedToEventLog;                                                                        // tracks location addition
        public bool locationAddedToEventLog { get => _locationAddedToEventLog; set => _locationAddedToEventLog = value; }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Player()                         // Constructor, calls SetPlayersStartingVariables on construction.
        {
            SetPlayersStartingVariables();
        }

        public void SetPlayersStartingVariables()                   // Set the players starting variables (health, inventory, event)
        {
            health = 75;
            inventory.Add("Pocket Knife");
            eventLog.Add("Washed ashore on a deserted island");
        }

    }
}
