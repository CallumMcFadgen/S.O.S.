using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace SOS
{
   public class EventLogViewController : MonoBehaviour
    {
        public Text UIEventLogDisplay;

        void Start()                // display events on start
        {
            DisplayEventLog();
        }


        public void DisplayEventLog()               // formats event log contents for display 
        {
            string events = string.Join("" + '\n', DataStore.player.eventLog.ToArray());
            UIEventLogDisplay.text = events;
        }


        public void ReturnToGameScreen()        // return to game screen
        { 
            SceneManager.LoadScene(DataStore.player.currentLocation);
        }


    }
}
