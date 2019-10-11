using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace SOS
{
    public class InventoryViewController : MonoBehaviour
    {
        public Text UIInventoryDisplay;

        void Start()                // display inventory items on start
        {
            DisplayInventory();
        }


        public void DisplayInventory()                          // formats inventory contents for display 
        {
            string items = string.Join("" + '\n', DataStore.player.inventory.ToArray());
            UIInventoryDisplay.text = items;
        }


        public void ReturnToGameScreen()        // return to previous game screen
        {
            SceneManager.LoadScene(DataStore.player.currentLocation);
        }


    }
}
