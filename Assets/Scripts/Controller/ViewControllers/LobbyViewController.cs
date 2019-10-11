using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


namespace SOS
{
    public class LobbyViewController: MonoBehaviour
    {
        public void StartNewGame()      // Create a new player instance, create a new event instance, create a new location instance, set player eventstate, set event log, open scene
        {
            DataStore.CreatePlayerInstance();
            DataStore.CreateEventInstance();
            DataStore.CreatelocationInstance();
            DataStore.player.eventState = 0;
            DataStore.player.locationAddedToEventLog = false;
            SceneManager.LoadScene("Beach");
        }


    }
}