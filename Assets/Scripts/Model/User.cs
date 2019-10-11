using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOS
{
    public class User
    {
        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* This class holds user email addresses and passwords for validating user logins, the two are intended to sync on the 
         * key value (1, useremail = 1, password).  Should be pretty stright forward to transfer to database */

        private Dictionary<string, string> _userCredentials = new Dictionary<string, string>();
        public Dictionary<string, string> userCredentials { get => _userCredentials; set => _userCredentials = value; }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /*A method to set admin credentials to allow inital access to the application */

        public void SetAdminCredentials()
        {
            userCredentials.Add("admin","P@ssword1");
            Debug.Log("SetAdminCredentials called");
        }
    }
}
 