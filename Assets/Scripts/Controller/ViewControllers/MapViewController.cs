using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace SOS
{
    public class MapViewController : MonoBehaviour
    {
        public Vector3 tempPosition;           // Holds the players current map location

        void Start()                // call SetLocation
        {
            SetMapLocation();
            Debug.Log(DataStore.player.currentLocation);
        }


        public void SetMapLocation()                   // assign a position, check previous location and change player map location
        {
            tempPosition = transform.position;

            if (DataStore.player.currentLocation == "Beach")
            {
                transform.position = transform.position = new Vector3(757.9f, 562.8f, 0.0f);
            }
            else if (DataStore.player.currentLocation == "Mangroves")
            {
                transform.position = transform.position = new Vector3(837.9f, 572.8f, 0.0f);
            }
        }


        public void ReturnToGameScreen()        // return to game screen
        {
            SceneManager.LoadScene(DataStore.player.currentLocation);
        }


    }
}
