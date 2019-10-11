using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SOS
{
    public class Event
    {
        // VARIABLES //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static Dictionary<string, string> _beachEvents = new Dictionary<string, string>();
        public Dictionary<string, string> beachEvents { get => _beachEvents; set => _beachEvents = value; }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Event()           // Constructor
        {
            LoadBeachEventText();
        }

        public void LoadBeachEventText()        // Load text for a range of events on at the beach location
        {
            Debug.Log("LoadBeachEventText call");

            // good
            beachEvents.Add("goodEventIntroText", "The tide has just washed out revealing some clumps of what could be an edibile seaweed.");
            beachEvents.Add("goodEventOutcomeText", "The seaweed is quite salty but luckly it is edible and you feel a bit better after eating it");

            // bad
            beachEvents.Add("badEventIntroText", "There is a strong smell in the air, it seems to be coming from behind some rocks on the beach.");
            beachEvents.Add("badEventOutcomeText", "You come face to face with an angry fur seal! It snaps at you but you manage to scramble away just in time, after the adrenaline wears off you notice several new bruises and scatches");

            //find
            beachEvents.Add("findEventIntroText", "It looks like theres something tangled in some driftwood near the hightide mark");
            beachEvents.Add("findEventOutcomeText", "At first you think it might just be some seaweed but as you untaggle the driftwood you find a length of fishing line with several hooks still attached.");

            // none/default
            beachEvents.Add("noEventText", "The waves wash in relentlessly as a strong salty breeze blows in from the sea");

            // take 
            beachEvents.Add("takeEventOutcomeText", "You carefully coil up the fishing line up and put it in your pocket, if you see some fish you could use the line to try to catch them.");

            Debug.Log("LoadBeachEventText success");
        }


    }
}
