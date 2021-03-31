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
        private BadgeRepository _badgeRepo = new BadgeRepository();


        //Menu
        private void Menu()
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
                        //Add a badge.
                        break;
                    case "2":
                        //Edit a badge.
                        break;
                    case "3":
                        //List all Badges/
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

        private void AddNewBadge()
        {
            Badge newBadge = new Badge();

            //BadgeID
            Console.WriteLine("Enter the new BadgeId you want to in the badge?\n");
            newBadge.BadgeID = int.Parse(Console.ReadLine().ToLower());

            //Floor Access
            Console.WriteLine("List a door that it needs access to\n");
            string typeOfAccess = Console.ReadLine().ToLower();

            _badgeRepo.AddBadge(newBadge);

            //description 
            Console.WriteLine("Any other doors (y/n");
            string FurtherAccess = Console.ReadLine().ToLower();

            if (FurtherAccess == "y")
            {
                newBadge.//somethinghere = true;

                //re-running the adding access instead of going out and doing it all over agin.
                Console.WriteLine("Door access has been set. Any more access to other doors you wish to update? (y/n) \n" +
                    "");

                string UpgradeAccess = Console.ReadLine().ToLower();

                if (UpgradeAccess == "y")
                {
                    newBadge.UpgradeAccess = true;
                }
            }
            else
            {
                Console.WriteLine($"Has only acccess to {FurtherAccess}");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
        }
        //Edit a badge. 
        private void UpdateExistingBadge()
        {
            DisplayAllBadge(); //haven't made displayallbadge yet!
            Console.Clear();
            Dictionary<int, string> = _badgeRepo.GetBadgeByID(); //haven't bad the function badgebyid yet. 

            //Ask for the BadgeId
            Console.WriteLine("What is the badge number you would like to update? \n" +
                "");
            string badgeId = Console.ReadLine().ToLower();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What would like you to do?\n" +
                    "1. Remove a door \n" +
                    "2. Add a door. \n" +
                    "3. Exit");

                //Get the user's input 

                string userinput = Console.ReadLine();

                //Evaulate the user's input and act accordingly to their needs.
                switch (userinput)
                {
                    case "1":
                        //Remove a door. The door excit is inside the list and inside of the dictionary. Find the badge thatyou're about to remove and find the specific door to remove.
                        break;
                    case "2":
                        //Add a door.
                        break;
                    case "3":
                        //List all Badges/
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
        public void RemoveDoor()
        {
            Console.WriteLine("Enter your BadgeID you wish to remove the door");

            int input = int.Parse(Console.ReadLine());

        }


        private void SeedBadgeList()
        {
            IDictionary<int, string> badgeList = new Dictionary<int, string>();
            badgeList.Add(12345, "A7");
            badgeList.Add(22345, "A1", "A4", "B1", "B2");


        }
    }
}
