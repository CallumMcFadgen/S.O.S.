using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOS
{
    public static class DataStore
    {
        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Variables for Player, Location, Event and User.  These will be used to hold instantiations of these classes */

        private static Player _player;
        public static Player player { get => _player; set => _player = value; }

        private static Location _location;
        public static Location location { get => _location; set => _location = value; }

        private static Event _event;
        public static Event @event { get => _event; set => _event = value; }

        private static User user;
        public static User User { get => user; set => user = value; }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Functions to create individual instances (Player, Event, Location, User) and a function create the user instance on start*/

        public static void CreatePlayerInstance()
        {
            player = new Player();
            Debug.Log("Player instance created");
        }

        public static void CreatelocationInstance()
        {
            location = new Location();
            Debug.Log("Location instance created");
        }

        public static void CreateEventInstance()
        {
            @event = new Event();
            Debug.Log("Event instance created");
        }

        public static void CreateUserInstance()
        {
            user = new User();
            Debug.Log("User instance created");
        }
    }
}
 