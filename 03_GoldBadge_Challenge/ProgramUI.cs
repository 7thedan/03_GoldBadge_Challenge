using Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03_GoldBadge_Challenge
{
    class ProgramUI
    {
        private bool _badgeListSeeded;
        private BadgeRepository _badgeRepo = new BadgeRepository();

        public void RunBadge()
        {
            SeedBadgeList();
            BadgeMenu();
        }

        //Menu
        public void BadgeMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do\n" +
                    "1. Add a Badge. \n" +
                    "2. Edit a Badge. \n" +
                    "3. List all Badges\n" +
                    "4. Exit");

                //Get the user's input 

                string input = Console.ReadLine();

                //Evaulate the user's input and act accordingly to their needs.
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateTheBadge();
                        break;
                    case "3":
                        
                        DisplayAllBadge();
                        break;
                    case "4":
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("The badge you entered does not exist in our database");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
            }
        }
        private void AddBadge()
        {

            Badge newBadge = new Badge
            {
                DoorAccess = new List<string>()
            };

            //BadgeID
            Console.Write("Enter the name for the Badge you want: ");
            newBadge.Name = Console.ReadLine();

            Console.Write("Enter the Badge ID you want: ");
            newBadge.BadgeID = int.Parse(Console.ReadLine());

            //List a door
            Console.WriteLine("Enter the list of a door that it needs access to");
            Console.WriteLine("Enter the following Door Access");
            Console.WriteLine("A1, A4, A5, A7, B1, B2"); //enter a door you need to access to. then get the one string they entered and add that to dooraccess list. after you got the doors you want and add you want more

            string door1 = Console.ReadLine().ToLower();
            newBadge.DoorAccess.Add(door1);

            _badgeRepo.AddBadge(newBadge.BadgeID, newBadge.DoorAccess);

            Console.Write("Any other door? (y/n)");
            string moreAccess = Console.ReadLine().ToLower();

            if (moreAccess == "y")
            {
                Console.WriteLine("Enter the list of a door that it needs access to");
                Console.WriteLine("Enter the following Door Access");
                Console.WriteLine("A1, A4, A5, A7, B1, B2"); //enter a door you need to access to. then get the one string they entered and add that to dooraccess list. after you got the doors you want and add you want more

                string door2 = Console.ReadLine().ToLower();
                _badgeRepo.AddDoorAccess(newBadge.BadgeID, door2);
            }
            else
            {
                Console.Clear();
                RunBadge();
            }
        }

        private void DisplayAllBadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> _displayBadge = _badgeRepo.GetBadges();

            if (_displayBadge.Count == 0) //you have to get all of the badges. 
            {
                Console.Clear();
                Console.WriteLine("Your claims list is empty! Press any key to go back to the menu.");
                Console.ReadLine();
                Console.Clear();
                RunBadge();
            }
            else
            {
                foreach (KeyValuePair<int, List<string>> kvp in _displayBadge)
                {
                    Console.WriteLine($"Badge ID = {kvp.Key}");
                    foreach(var doorAccess in kvp.Value)
                    {
                        Console.WriteLine($"Has access to {doorAccess}");
                    }
                }
            }
        }

        private void UpdateTheBadge() //doesnt take my parameters
        {
            DisplayAllBadge();

            Dictionary<int, List<String>> _badgerepo = new Dictionary<int, List<String>>();
            //display all badge and pull the badge that you want. 

            Console.Write("Enter the Badge you'd like to update");

            // I am making a new badge instead of getting the badge by id. I am not using it. Take the id by the user and pass that in by id method. 

            int originalBadgeID = int.Parse(Console.ReadLine());

            KeyValuePair<int, List<string>> badge = _badgeRepo.GetBadgeByID(originalBadgeID); //pass it into this method

            //we can access the list of strings which is our value "badge" dooraccess. through the dot notation can use the remove method that's already built in. 

            //pass on the int to the reponsitory method.

            //kvp doesnt have a lot of thing. You dont have a count for  kvp. 
            //.KEY Aanother class. like badge. methods, properties, adn creating other instances those classes you can access what it's in them and that's what dot notation. Access the badge id, dooraccess, name due to dot notation.

            if (badge.Value.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your BadgeID is empty! Press any key to go back to the menu.");
                Console.ReadLine();
                Console.Clear();
                BadgeMenu();
            }
            else
            {
                Console.Clear();
                //display the next claim
                Console.WriteLine($"{badge.Key}"); //through key value pair we can access the properties that are in it.

                Console.Write("Would you like to give or remove access to a door (give/remove)?");
                string option = Console.ReadLine().ToLower();

                if (option == "remove")
                {
                    Console.Write("Which door would you like to remove?");
                    string doorToRemove = Console.ReadLine();
                    //badge.DoorAccess.Add(door1);
                    _badgeRepo.RemoveAccess(badge.Key, doorToRemove);

                    Console.Write("You have removed the access. Would you like to remove more access? (y/n)");
                    string removeMore = Console.ReadLine();

                    if (removeMore == "y")
                    {
                        Console.WriteLine("Which door would you like to remove?"); //enter a door you need to access to.
                                                                   //then get the one string they entered and add that to dooraccess list.
                                                                   //after you got the doors you want and add you want more
                        string nextDoorToRemove = Console.ReadLine().ToLower();
                        _badgeRepo.RemoveAccess(badge.Key, nextDoorToRemove);
                    }
                    else
                    {
                        Console.Clear();
                        RunBadge();
                    }
                }
                else if (option == "give")
                {
                    Console.WriteLine("Which door would you like to give access?");
                    string doorToAdd = Console.ReadLine();
                    _badgeRepo.AddDoorAccess(badge.Key, doorToAdd);

                    Console.Write($"You have given acccess to door {doorToAdd}. Would you want to add another access? (y/n)");
                    string moreAccess = Console.ReadLine();

                    if (moreAccess == "y")
                    {
                        Console.WriteLine("Which door would you like to give access?");
                        string nextDoorToAdd = Console.ReadLine();
                        _badgeRepo.AddDoorAccess(badge.Key, nextDoorToAdd);
                    }
                    else
                    {
                        Console.Clear();
                        RunBadge();
                    }
                }
            }
        }

        private void SeedBadgeList()
        {
            if (!_badgeListSeeded)
            {
                Badge access1 = new Badge(12345, 
                    new List<string>() { "A7"}, "Austin");

                Badge access2 = new Badge(22345,
                    new List<string>() { "A1","B1","B2"}, "Nick");
                
                Badge access3 = new Badge(32345,
                    new List<string>() { "A4","A5"}, "Erick");

                _badgeRepo.AddBadge(access1.BadgeID, access1.DoorAccess);
                _badgeRepo.AddBadge(access2.BadgeID, access2.DoorAccess);
                _badgeRepo.AddBadge(access3.BadgeID, access3.DoorAccess);

                _badgeListSeeded = true;
            }
        }
    }
}
