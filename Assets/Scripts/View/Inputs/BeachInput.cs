using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SOS
{
    public class BeachInput : MonoBehaviour
    {
        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

       // BeachController Instance
       public BeachController beachController;              // Create a BeachController instance 

        // Input Variables
        public InputField UIInput;                          // The input field for user input
        InputField.SubmitEvent submittedInput;              // Used to register user pressing enter for data input
        public string userInput;                            // The data that the user has enetered


        // START FUNCTIONS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Start()       // Starting variable assignment and function                
        {
            CreateBeachControllerInstance();            // Create a new beach controller
            beachController.Start();                    // Call the BeachControllers start function (starts the level)
            ActivateInputField();                       // Set the input field to be active on the level start
            SubmitInput();                              // Set the input field to submit input
        }

        public void CreateBeachControllerInstance()     // Create a new beach controller
        {
            beachController = new BeachController();
        }


        // INPUT FUNCTIONS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ActivateInputField()               // Set the input field to be active on the level start
        {
            UIInput.ActivateInputField();
        }


        public void SubmitInput()                                   // Pass the input in from the text field on enter
        {
            submittedInput = new InputField.SubmitEvent();
            submittedInput.AddListener(GetInput);
            UIInput.onEndEdit = submittedInput;
        }


        public void GetInput(string input)          // Save the user input to a variable, clear the input field and calls update display and input check
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                userInput = input;
                Debug.Log(userInput);
                UIInput.text = null;
                UIInput.ActivateInputField();


                //DisplayInput();
                beachController.CheckInput(userInput);
            }
        }

        
        // BUTTON FUNCTIONS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void QuitGame()      // Quits the application (more work needed)
        {
            beachController.OpenScene("Lobby");
        }


        public void InventoryScene()        // Opens the inventory screen
        {
            beachController.OpenScene("Inventory");
        }


        public void EventLogScene()         // Opens the event log scene 
        {
            beachController.OpenScene("EventLog");
        }


        public void MapScene()                  // Opens the map scene
        {
            beachController.OpenScene("Map");
            Debug.Log(DataStore.location.name);
        }


    }
}
