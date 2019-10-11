using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SOS
{ 
    public class LoginController
    {

        public void CheckInput(string usernameInput, string passwordInput)
        {
            if (!string.IsNullOrWhiteSpace(usernameInput) && !string.IsNullOrWhiteSpace(passwordInput))
            {
                CheckUserCredentials(usernameInput, passwordInput);
            }
        }



        public void CheckUserCredentials(string usernameInput, string passwordInput)
        {
            if (DataStore.User.userCredentials.Contains(new KeyValuePair<string, string>(usernameInput, passwordInput)))
            {
                Debug.Log("succesful authentication");
                SceneManager.LoadScene("Lobby");
            }
            else
            {
                Debug.Log("unsuccesful authentication");
                SceneManager.LoadScene("Login");
            }
        }


    }
}
