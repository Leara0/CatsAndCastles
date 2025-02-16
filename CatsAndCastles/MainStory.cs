namespace CatsAndCastles;

public class MainStory
{
    public static void RunGame()
    {
        MainRoom mainRoom = new MainRoom();

        Characters cat = new Characters();
        cat.Name = cat.GetName();

        BackPack backPack = new BackPack();
        backPack.Pack = new string[5]; // creates a new pack that holds 5 items 
        for (int i = 0; i < backPack.Pack.Length; i++) // fills back with "" for later checks 
        {
            backPack.Pack[i] = "";
        }

        backPack.DiscardedItems = new List<string>(); // create a record of all items that have been discarded 
        backPack.ListOfAllItemsPickedUp = new List<string>(); //keep track of all items that have been picked up 

        Fight fight = new Fight(); // @fix move this to later when needed

        mainRoom.Intro();
        mainRoom.FirstWakeUp(cat.Name);
        mainRoom.StartInRoom();
        FirstRoomChoices(mainRoom, backPack, fight);
        
    }

    public static void FirstRoomChoices(MainRoom mainRoom, BackPack backPack, Fight fight)
    {
        string userChoice = mainRoom.FirstRoomOptions(backPack.Pack, backPack.DiscardedItems);
        switch (userChoice) //@fix adjust this after removing 9
        {
            case "1":
                ExploreDoor();
                break;
            case "2":
                ExploreCloset(); //@done 
                break;
            case "3":
                ExploreWindow(); //@done
                break;
            case "4":
                ExploreNightStand(); //@done
                break;
            case "5":
                ExploreBookshelf(); //@done
                break;
            case "6":
                ExploreHearth(); //@done
                break;
            case "7":
                backPack.ListContentsOfPack();
                Console.WriteLine("Would you like to remove any items?" +
                                  "\nPlease press '1' to remove an item and '2' to continue exploring the room");
                while (mainRoom.UserChoice() == "1")
                {
                    backPack.RemoveItemsFromPack();
                    backPack.ListContentsOfPack();
                    Console.WriteLine("Would you like to remove another item?" +
                                      "\n Press '1' to remove another item and '2' to continue exploring the room");
                }

                FirstRoomChoices(mainRoom, backPack, fight);
                break;
            case "8":
                backPack.PickUpItemsFromDiscarded();
                FirstRoomChoices(mainRoom, backPack, fight);
                return; //@fix is this the right thing here?
            case "9":
                string choice = fight.ChooseWeapon(backPack.Pack);
                Console.WriteLine($"You chose {choice}");
                Console.WriteLine("Press 'enter'");
                Console.ReadLine();
                FirstRoomChoices(mainRoom, backPack, fight);
                break;
        }
    }
}