using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace SOS
{
    public class MangrovesViewController : MonoBehaviour
    {
        // Instances
       // Location location = new Location();     //location instance

        // UI Elements
        public Text UIHealthValue;              // Player health here
        public Text UILocationName;             // Location name here
        public Text UITextDisplay;              // Text displayed here (location description + event description + "what will you do?")
        public Text UIInventory;                // Inventory items here
        public InputField UIInput;              // input field for user input

        // Player Variables
        public int health;                      // Players health value
        public List<string> inventory;          // Players inventory
        public List<string> eventLog;           // Players event log

        // Location Variables
        public string sceneName;                                // Current scene name (for navigation and map location)
        public string locationName;                             // Name for UI Loaction name
        public string locationDescription;                      // Description for UI scene description
        public string textDisplay;                              // Formated text for UI display
        public string callToAction = "What will you do?";       // Generic call to action

        // Event Variables
        public string eventDescription;         // UI event description

        // Input Variables
        InputField.SubmitEvent submittedInput;      // used to register user pressing enter
        public string userInput;                    // the data the user has enetered


        /// Start Functions //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Start()     // Set and display relevant variables on start
        {
            SetLocationVariables();
            SetPlayerVariables();
            SetEventVarables();
            CheckEventLogCleared();
            UpdateUIDisplay();
            SubmitInput();
            UIInput.ActivateInputField();
            //StartBackgroundSound();
        }


        /// Update Functions /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Update()
        {

        }


        /// Variable Assignment Functions ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetPlayerVariables()        // Populates variables with relevant player values taken from passed variables via Player.Prefs
        {
            string playerInventory = PlayerPrefs.GetString("playerInventory");
            string playerEventLog = PlayerPrefs.GetString("playerEventLog");

            health = PlayerPrefs.GetInt("playerHealth");
            inventory = playerInventory.Split(',').ToList();
            eventLog = playerEventLog.Split(',').ToList();
            eventLog.Add(("Location - " + sceneName));
        }

        public void SetLocationVariables()      // Populates variables with relevant location values
        {
            sceneName = SceneManager.GetActiveScene().name;
            locationName = "Mangroves";
            //locationDescription = location.LocationDescriptions[locationName];
        }

        public void SetEventVarables()      // Populates variables with relevant event values
        {
            eventDescription = "-(Event description text will be displayed here)-";
        }


        /// UI  Functions ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateUIDisplay()       // Sets some variables for display formating and sets the values of UI text to match variable values
        {
            string inventoryItems = string.Join("" + '\n', inventory.ToArray());

            textDisplay = (locationDescription + '\n' + '\n' + eventDescription + '\n' + '\n' + callToAction + '\n' + '\n');

            UIHealthValue.text = health.ToString();
            UILocationName.text = sceneName;
            UIInventory.text = inventoryItems;
            UITextDisplay.text = textDisplay;
        }

        //public virtual void StartBackgroundSound(soundName)      // Start relevant background sound
        //{

        //}


        /// Input Processing Functions //////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SubmitInput()       // Pass the input from the text field on enter
        {
            submittedInput = new InputField.SubmitEvent();
            submittedInput.AddListener(GetInput);
            UIInput.onEndEdit = submittedInput;
        }

        public void GetInput(string input)      // save the user input to a variable, clear the input field and calls update display and check input
        {
            userInput = input;
            UIInput.text = null;
            UIInput.ActivateInputField();
            CheckInput();
        }

        public void CheckInput()             // format user input then check if it meets condition, if yes then run, if not then display error.               
        {
            string formattedInput = userInput.ToLower();

            if (formattedInput == "go west")
            {
                string currentTextDisplay = UITextDisplay.text;
                string updatedTextDisplay = (currentTextDisplay + "<b>" + userInput + "</b>" + '\n' + '\n');
                UITextDisplay.text = updatedTextDisplay;
                OpenBeachScene();
            }
            else
            {
                string currentTextDisplay = UITextDisplay.text;
                string updatedTextDisplay = (currentTextDisplay + "<b>" + userInput + "</b>" + '\n' + '\n' + "Im sorry, I cant do that" + '\n' + '\n');
                UITextDisplay.text = updatedTextDisplay;
            }
        }


        /// Sceen Navigation Functions //////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OpenBeachScene()        // formates and saves player variables for next scene via Player.Prefs and clears the event log marker
        {
            string inventoryItems = string.Join(",", inventory.ToArray());
            string eventLogEvents = string.Join(",", eventLog.ToArray());
            string setEvent = "true";

            ResetEventlogStatus();

            PlayerPrefs.SetInt("playerHealth", health);
            PlayerPrefs.SetString("playerInventory", inventoryItems);
            PlayerPrefs.SetString("playerEventLog", eventLogEvents);
            SceneManager.LoadScene("Beach");
            PlayerPrefs.SetString("setLocationEvent", setEvent);
        }

        public void OpenEventLogScene()    // Saves current scene name and event log to player pref and opens the EventLog Screen
        {
            string eventLogEvents = string.Join("" + '\n', eventLog.ToArray());
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetString("logToDisplay", eventLogEvents);
            SceneManager.LoadScene("EventLog");
        }

        public void OpenInventoryScreen()       // Saves current scene name and inventory items to player pref and opens the Inventory Screen
        {
            string inventoryItems = string.Join(",", inventory.ToArray());
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetString("inventoryToDisplay", inventoryItems);
            SceneManager.LoadScene("Inventory");
        }

        public void OpenMapScreen()       // Saves current Scene Name and opens the Map Screen
        {
            //PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene();
        }


        /// Gameplay Functions //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void IncreaseHealth(int increase)        // Increse health, but if over 100, set to 100 (max health)
        {
            health += increase;

            if (health >= 100)
            {
                health = 100;
            }
        }

        public void ReduceHealth(int reduction)     // Decrease health, but if 0 or under, call PlayerDead
        {
            health -= reduction;

            if (health <= 0)
            {
                PlayerDead();
            }
        }

        public void PlayerDead()        // Player is dead (health under 0)
        {
            Debug.Log("player is dead");
        }


        /// General Functions //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void CloseApplication()      // Quit the application
        {
            Debug.Log("CloseApplication Called");
            Application.Quit();
        }

        public void CheckEventLogCleared()      // Check if the event log was cleared in the eventlog screen and if it was clear the event log
        {
            string clearEventLog = PlayerPrefs.GetString("clearEventLog");

            if (clearEventLog == "true")
            {
                eventLog.Clear();
            }
        }

        public void ResetEventlogStatus()       // Reset the clear event log marker
        {
            string clearEventLog = "";
            clearEventLog = "false";
            PlayerPrefs.SetString("clearEventLog", clearEventLog);
        }


    }
}
