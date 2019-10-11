using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace SOS
{
    public class LoginInput : MonoBehaviour
    {
        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // loginController instance
        public LoginController loginController;              // Create a LoginController instance 

        // Variables for username and password input

        public Text UIUsername;
        public Text UIPassword;

        public string usernameInput;
        public string passwordInput;


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Start()
        {
            CreateLoginControllerInstance();
        }


        public void CreateLoginControllerInstance() 
        {
            loginController = new LoginController();
        }


        public void AcceptUserInput()
        {
            usernameInput = UIUsername.text;
            Debug.Log(usernameInput);

            passwordInput = UIPassword.text;
            Debug.Log(passwordInput);

            loginController.CheckInput(usernameInput, passwordInput);
        }



    }
}