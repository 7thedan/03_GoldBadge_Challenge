using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _badgerepo = new Dictionary<int, List<String>>();

        //creating a list one and store value

        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgerepo;
        }
        
        public bool UpdateBadge(int originalBadgeID, string olddoor, string newdoor) /*(int oldAccess, Badge newBadge)*/ //updating a badge. 1. Need to find the badge/access and it's information. 2. Request the change 3. Update the badge. 
        {
            var existingBadge = _badgerepo.ContainsKey(originalBadgeID);

            if (!existingBadge)
            {
                return false;
            }

            var existingDoorIndex = _badgerepo[originalBadgeID].FindIndex(d => d == olddoor);

            if (existingDoorIndex >= 0)
            {
                _badgerepo[originalBadgeID][existingDoorIndex] = newdoor; //go to badge repo dictionary and other bracket indexing to a list. Go to that list in an element which is1.
            }                               //return the value of that newdoor. Override that. How to be more advance in treatment of dictionary. 

            return true;
        }

        public void AddBadge(int id, List<string> dooraccess) // 1. adding a badge means need to create id 2. create the dooraccess. 3. Keep it in the storage. 
        {
            var existingBadge = _badgerepo.ContainsKey(id); //return true or false for that id. Dictionary is searched by Key.
            
            if (!existingBadge)
            {
                _badgerepo.Add(id, dooraccess);
            }
        }

        public void AddDoorAccess(int id, string door) // 1. adding a badge means need to create id 2. create the dooraccess. 3. Keep it in the storage. 
        {
            var badge = GetBadgeByID(id);

            if (badge.Value.Count > 0)
            {
                //Instead of having both adding and removing access. Having behavior for solid principle. 
                badge.Value.Add(door);
            }
        }

        public bool RemoveAccess(int id, string door)
        {
            var badge = GetBadgeByID(id);

            if (badge.Value.Count > 0)
            {
                // not null then we know it exist. start at the top dictionary. with what i have what is the type. what do i need to do. remove an item from the dictoionary and how could that fail and where would that fail. If you fail if you remove something if it doesnt exist.if it does not exist forget it. If it does remove it.
                badge.Value.Remove(door);

                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper method from other challenges.
        public KeyValuePair<int, List<string>> GetBadgeByID(int id) //put a int a type. Pass the variable. Type and the actual container. Cookie jar. Iterate through dictionary. 
        {
            var badge = new KeyValuePair<int, List<string>>();

            foreach (KeyValuePair<int, List<string>> b in _badgerepo) //keys are int values in the dictionary.
            {
                if (b.Key == id) //Key represnt the int value, and Values represnets the list of strings. 
                {
                    badge = b;
                    break;
                }
                //conversation is the UI. Type of pizza. Take your input and put it into your method. Then they make the pizza with the ingreidents. Then returns the pizza object. 
            }

            return badge; //return type something other then nul
        }
        //through the badge we captured in the UI
    }
}
