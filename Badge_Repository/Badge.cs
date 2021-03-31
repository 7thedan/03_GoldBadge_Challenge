using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    //public enum BadgeAccess
    //{
    //    A = 1,
    //    B = 2,
    //}

    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }
        public bool UpgradeAccess { get; set; } // use variables for the UI

        public Badge() { }

        public Badge(int badge_id, List<string> door_access, bool upgradeaccess)
        {
            BadgeID = badge_id;
            DoorAccess = door_access;
            UpgradeAccess = upgradeaccess;
        }

    }

}
