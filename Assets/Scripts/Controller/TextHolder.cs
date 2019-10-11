using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOS
{
    public static class TextHolder
    {
        private static string _mainTextDisplay;
        public static string mainTextDisplay { get => _mainTextDisplay; set => _mainTextDisplay = value; }


        public static void SetTextDisplayContent(string textForDisplay)
        {
            mainTextDisplay = textForDisplay;
            Debug.Log(mainTextDisplay);
        }


    }
}
