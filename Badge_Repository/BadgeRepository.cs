using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepository
    {
        Dictionary<int, List<String>> _badgerepo = new Dictionary<int, List<String>>();

        //creating a list one and store value
        //List<string> _badgerepo 

        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgerepo;
        }

        //Helper method from other challenges.
        public KeyValuePair<int, List<string>> GetBadgeByID(int id) //put a int a type. Pass the variable. Type and the actual container. Cookie jar. Iterate through dictionary. 
        {
            KeyValuePair<int, List<String>> emptyKey = new KeyValuePair<int, List<string>>();   //empty. Break down the problem. 
            foreach(KeyValuePair<int, List<string>> badge in _badgerepo) //keys are int values in the dictionary.
            {
                if(badge.Key == id) //Key represnt the int value, and Values represnets the list of strings. 
                {
                    return badge;
                }
                //conversation is the UI. Type of pizza. Take your input and put it into your method. Then they make the pizza with the ingreidents. Then returns the pizza object. 
            }
            return emptyKey;
        }
        public void UpdateBadge(int id, Badge newBadge) //updating a badge. 1. Need to find the badge and it's information. 2. Request the change 3. Update the badge. 
        {
            
        }
        public bool AddBadge(int originalBadge, Badge newBadge) // 1. adding a badge means need to create id 2. create the dooraccess. 3. Keep it in the storage. 
        {
            Badge oldBadge = GetBadgeByID(originalBadge);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = new.badge_id;
                oldBadge.DoorAccess = new.DoorAccess;
           

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveBadge(int id)
        {
            Badge badge = GetBadgeByID(id);

            if (badge == null)
            {
                return false;
            }

            int initialCount = _badgerepo.Count;
            _badgerepo.Remove(badge);

            if (initialCount > _badgerepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDoor(string dooraccess)
        {
            Badge door = GetBadgeByID(dooraccess)

        }
    }
       
        private void SeedFloorAccess()
        {
            _badgerepo.Add(12345, "A7");
            _badgerepo.Add(22345, "A1");
            _badgerepo.Add(32345, "A4", "A5");



        }
    }
    }
}
