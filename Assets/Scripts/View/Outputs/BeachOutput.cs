using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SOS
{ 
    public class BeachOutput : MonoBehaviour
    {
        // UI Elements
        public Text UIHealthValue;                                      // Player health display
        public Text UILocationName;                                     // Location name display
        public Text UITextDisplay;                                      // Text displayed area (location description + event description + "what will you do?")
        public Text UIInventory;                                        // Inventory items display
        public string currentTextDisplay;                               // Current Text display content


        public void Start()
        {
            UpdateHealth();
            UpdateLocationName();
            UpdateInventory();
            UpdateTextArea();
            UpdateCurrentText();
        }
        

        public void Update()
        {
            UpdateHealth();
            UpdateInventory();
            UpdateTextArea();
            UpdateCurrentText();
        }


        public void UpdateHealth()                                              // update the health display
        {
            UIHealthValue.text = DataStore.player.health.ToString();
        }


        public void UpdateLocationName()                                        // update the location name display
        {
            UILocationName.text = DataStore.location.name;
        }


        public void UpdateInventory()                                                                       // update the inventory display
        {
            UIInventory.text = string.Join("" + '\n', DataStore.player.inventory.ToArray());            // To set up in beach view
        }

        public void UpdateTextArea()                                 // concatenates text into a string for displaying in the text area
        {
            UITextDisplay.text = TextHolder.mainTextDisplay;
        }


        public void UpdateCurrentText()
        {
            currentTextDisplay = UITextDisplay.text;
        }


    }
}