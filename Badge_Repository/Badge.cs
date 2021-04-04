using System.Collections.Generic;

namespace Badge_Repository
{


    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }
        public string Name { get; set; }
        public Badge() { }

        public Badge(int badge_id, List<string> door_access, string name)
        {
            BadgeID = badge_id;
            DoorAccess = door_access;
            Name = name;
        }

    }

}
