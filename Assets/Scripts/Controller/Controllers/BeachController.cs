using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SOS
{
    public class BeachController
    {
        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Text formatting for display
        public string locationDescription;                     // Location description for concationation
        public string eventText;                               // Event text for concationation (intro, outro, outcome, etc)
        public string callToAction;                            // Generic call to action for display text concationation
        public string invalidInputResponse;                    // Generic error catching for display text concationation

        public string textDisplay;                             // All text concationated together for UI display
        public string previousTextDisplay;                     // The inital text for the level
        public string updatedTextDisplay;

        // User input for processing
        public string userInput;                                // The users input text


        // STARTUP FUNCTIONS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Start()
        {
            AssignCurrentSceneName();           // Assign a scene name for navigation
            AddToEventLog();                    // Create a new event log entry for this location ("visited beach")
            SelectEventType();                  // Roll a dice to select the type of event available

            SetLocationDescription();           // Set a string for displaying the locations description text
            SetEventIntroText();                // Set a string for displaying the locations event text
            SetCallToAction();                  // Set a string for displaying a generic "What will you do?" message
            SetInvalidInputResponse();          // Set a string for displaying a generic "I dont understand" message

            SetInitialTextDisplay();            // Create a block of text for the inital display
        }

        public void Update()
        {

        }

        public void AssignCurrentSceneName()        // Assign a scene name for navigation
        {
            DataStore.player.currentLocation = SceneManager.GetActiveScene().name;
            DataStore.location.name = SceneManager.GetActiveScene().name;
        }


        public void AddToEventLog()         // Create a new event log entry for this location ("visited beach")
        {
            if (DataStore.player.locationAddedToEventLog == false)
            {
                DataStore.player.eventLog.Add("Visited the " + DataStore.location.name);
                DataStore.player.locationAddedToEventLog = true;
            }
        }


        public void SetLocationDescription()                                       // update the location description text
        {
            locationDescription = DataStore.location.description["Beach"];
        }


        public void SelectEventType()        // select an event for the location based on a random number (random choice of good, bad, find, none)
        {
            int randomNumber = Random.Range(1, 10);       // Set random number

            if (DataStore.player.eventState == 0)            // Check that the player is ready for a new event
            {
                if (randomNumber == 1 || randomNumber == 2)          // Good event (2 out of 10)
                {
                    DataStore.player.eventState = 1;                                    // Set event state (good event)
                    Debug.Log("player event state" + DataStore.player.eventState);
                }
                else if (randomNumber == 3 || randomNumber == 4)             // bad event (2 out of 10)
                {
                    DataStore.player.eventState = 2;                                    // set event type  (bad event)
                    Debug.Log("player event state" + DataStore.player.eventState);
                }
                else if (randomNumber == 5 && !SOS.DataStore.player.inventory.Contains("Fishing Line"))       // find event (1 out of 10) (if the player does not have the item)
                {
                    DataStore.player.eventState = 3;                                    // set event type (find event)
                    Debug.Log("player event state" + DataStore.player.eventState);
                }
                else                                                                  // no event (5 out of 10)
                {
                    DataStore.player.eventState = 5;                                        // set event type (no event/default)
                    Debug.Log("player event state" + DataStore.player.eventState);
                }
            }
        }


        public void SetEventIntroText()                            // set the event description text based on the event selected for the scene
        {
            if (DataStore.player.eventState == 1)                        // good event (+ health)
            {
                eventText = DataStore.@event.beachEvents["goodEventIntroText"];
            }
            else if (DataStore.player.eventState == 2)                          // bad event (-health)
            {
                eventText = DataStore.@event.beachEvents["badEventIntroText"];
            }
            else if (DataStore.player.eventState == 3 && !DataStore.player.inventory.Contains("Fishing Line"))              // find event (if the player doesn't already have a fishing line)
            {
                eventText = DataStore.@event.beachEvents["findEventIntroText"];
            }
            else if (DataStore.player.eventState == 5)                                         // no event, placeholder text     
            {
                eventText = DataStore.@event.beachEvents["noEventText"];
            }
            Debug.Log(DataStore.player.eventState);
        }


        public void SetCallToAction()                       // set a default call to action for display
        {
            callToAction = "What will you do?";
        }


        public void SetInvalidInputResponse()                           // set a default error catch for input
        {
            invalidInputResponse = "Im sorry I dont understand";
        }


        public void SetInitialTextDisplay()           // Create a string for the initial text display
        {
            textDisplay = ('\n' + locationDescription + '\n' + '\n' + eventText + '\n' + '\n' + callToAction + '\n' + '\n');
            previousTextDisplay = textDisplay;
            TextHolder.SetTextDisplayContent(textDisplay);
        }


        //public virtual void StartBackgroundSound(soundName)      // Start relevant background sound (TBC)
        //{

        //}


        // INPUT FUNCTIONS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CheckInput(string input)          // Format user input then check if it meets condition, if yes then run, if not then display error.
        {
            userInput = input;                             // Set the userInput variable to the users input
            string formattedInput = input.ToLower();       // Format user input to lower case for processing
            Debug.Log(formattedInput);

            if (formattedInput == "go east")         // Go east
            {
                GoEastEventResponse();                                                         
            }
            else if (DataStore.player.eventState == 1 && formattedInput == "eat seaweed")            // Eat seaweed
            {
                EatSeaweedEventResponse();
            }
            else if (DataStore.player.eventState == 2 && formattedInput == "search rocks")             // Seal attack
            {
                SealAttackEventResponse();
            }
            else if (DataStore.player.eventState == 3 && formattedInput == "search driftwood")         // Find fishing line
            {
                FindLineEventResponse();
            }
            else if (DataStore.player.eventState == 4 && formattedInput == "take fishing line")            // Take fishing line
            {
                TakeLineEventResponse();
            }
            else                                                                                    // Invalid Input
            {
                InvalidInputEventResponse();
            }
        }


        public void GoEastEventResponse()                  // Set the players event state, open the mangrove scene
        {
            DataStore.player.locationAddedToEventLog = false;
            DataStore.player.eventState = 0;
            OpenScene("Mangroves");
        }


        public void EatSeaweedEventResponse()          // Increase the players health, set text display, set player event state, save text as previous text (for text formatting), update the display text
        {
            IncreaseHealth(2);
            DataStore.player.eventState = 5;
            string outCome = DataStore.@event.beachEvents["goodEventOutcomeText"];
            textDisplay = (previousTextDisplay + "<b>" + userInput + "</b>" + '\n' + '\n' + outCome + '\n' + '\n' + "<b>" + "gain 2 health points" + "</b>" + '\n' + '\n' + callToAction + '\n' + '\n');
            previousTextDisplay = textDisplay;
            TextHolder.SetTextDisplayContent(textDisplay);
        }


        public void SealAttackEventResponse()       // Reduce the players health, set text display, set player event state, save text as previous text (for text formatting), update the display text
        {
            ReduceHealth(5);
            DataStore.player.eventState = 5;
            string outCome = DataStore.@event.beachEvents["badEventOutcomeText"];
            textDisplay = (previousTextDisplay + "<b>" + userInput + "</b>" + '\n' + '\n' + outCome + '\n' + '\n' + "<b>" + "lose 5 health points" + "</b>" + '\n' + '\n' + callToAction + '\n' + '\n');
            previousTextDisplay = textDisplay;
            TextHolder.SetTextDisplayContent(textDisplay);
        }


        public void FindLineEventResponse()                   // Set the players event state, set text display, save text as previous text (for text formatting), update the display text
        {
            DataStore.player.eventState = 4;
            string outCome = DataStore.@event.beachEvents["findEventOutcomeText"];
            textDisplay = (previousTextDisplay + "<b>" + userInput + "</b>" + '\n' + '\n' + outCome + '\n' + '\n' + callToAction + '\n' + '\n');
            previousTextDisplay = textDisplay;
            TextHolder.SetTextDisplayContent(textDisplay);
        }


        public void TakeLineEventResponse()
        {
            AddToInventory("Fishing Line");
            DataStore.player.eventState = 5;
            string outCome = DataStore.@event.beachEvents["takeEventOutcomeText"];
            textDisplay = (previousTextDisplay + "<b>" + userInput + "</b>" + '\n' + '\n' + outCome + '\n' + '\n' + callToAction + '\n' + '\n');
            previousTextDisplay = textDisplay;
            TextHolder.SetTextDisplayContent(textDisplay);
        }

        public void InvalidInputEventResponse()         // Set text display, set player event state, save text as previous text (for text formatting), up date the display text
        {
            DataStore.player.eventState = 5;
            textDisplay = (previousTextDisplay + "<b>" + userInput + "</b>" + '\n' + '\n' + invalidInputResponse + '\n' + '\n' + callToAction + '\n' + '\n');
            previousTextDisplay = textDisplay;
            TextHolder.SetTextDisplayContent(textDisplay);
        }


        // GAMEPLAY FUNCTIONS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void IncreaseHealth(int increase)        // Increse the players health but if it goes over 100, return it to 100 (100 is max health)
        {
            DataStore.player.health += increase;

            if (DataStore.player.health >= 100)
            {
                DataStore.player.health = 100;
            }
        }


        public void ReduceHealth(int reduction)     // Decrease the players health by the specified amount and if the players health drops bellow zero, call PlayerDead
        {
            DataStore.player.health -= reduction;

            if (DataStore.player.health <= 0)
            {
                PlayerDead();
            }
        }


        public void PlayerDead()        // Player is dead (health under 0), do stuff
        {
            Debug.Log("player is dead");
        }


        public void AddToInventory(string item)         // Add a specified item to the plazyers inventory and update the UI display
        {
            DataStore.player.inventory.Add(item);
        }


        // NAVIGATION FUNCTIONS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OpenScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }


    }
}
