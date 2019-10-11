using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SOS
{
    public class TitleViewController : MonoBehaviour
    {
        /* This class contains a function to create a new User instance, Set the admin Credentials(temp) and load the login screen */

        public void OpenLoginScreen()
        {
            DataStore.CreateUserInstance();
            DataStore.User.SetAdminCredentials();
            SceneManager.LoadScene("Login");
        }
    }
}