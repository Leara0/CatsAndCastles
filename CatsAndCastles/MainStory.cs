namespace CatsAndCastles;

public class MainStory
{
    public static void RunGame()
    {
        MainRoom mainRoom = new MainRoom();

        Characters cat = new Characters();
        cat.Name = cat.GetName();
<<<<<<< HEAD
        cat.Health = 60;
=======
>>>>>>> testing

        BackPack backPack = new BackPack();
        backPack.Pack = new string[5]; // creates a new pack that holds 5 items 
        for (int i = 0; i < backPack.Pack.Length; i++) // fills back with "" for later checks 
        {
            backPack.Pack[i] = "";
        }

        backPack.DiscardedItems = new List<string>(); // create a record of all items that have been discarded 
        backPack.ListOfAllItemsPickedUp = new List<string>(); //keep track of all items that have been picked up 

<<<<<<< HEAD
        MainRoomWithExitStrategies(cat, backPack, mainRoom);

        // you end up here if you fall out of the exit strategies loop - ie if you
        // die and choose not to escape
        if (cat.Status == cat.Dead)
            Console.WriteLine("\nAs the darkness takes hold, a strange sense of peace washes over you. " +
                              "The struggle, the fear, the desperate clawing for survival — it all fades into " +
                              "nothingness.\n\nThe castle will remain, its cold stone walls holding secrets " +
                              "you will never uncover. The paths you might have taken, the dangers you might " +
                              "have bested, all slip away like mist in the morning sun." +
                              "\n\nPerhaps you were never meant to escape." +
                              "\n\nAnd so, the little explorer’s journey comes to an end." +
                              "\n\nGame Over.");
    }

    public static void MainRoomWithExitStrategies(Characters cat, BackPack backPack, MainRoom mainRoom)
    {
        mainRoom.RunMainRoom(cat, backPack);
        do // you get here after you come to the end of one of the main room story lines
        {
            switch (cat.Status)
            {
                case "passed out": //@add something about taking health in main room
                    PassOut(cat, backPack);
                    break;
                case "third floor":
                    ThirdFloor thirdFloor = new ThirdFloor();
                    thirdFloor.ThirdFloorStory(cat, backPack);
                    break;
                case "second floor":
                    break;
                //@add need to add second and first floors
                case "outside castle":
                    OutsideCastle(cat, backPack);
                    break;
            }
        } while (cat.NotEscapedCastle);
    }

    static void PassOut(Characters cat, BackPack backPack)
    {
        cat.Lives--;
        Console.WriteLine(
            "\nThe pain is immediate and blinding, the world tilts around you, and darkness swallows you whole. " +
            "For a moment, there is nothing—no pain, no sound, no sense of time. " +
            "Then, a strange awareness creeps in. A feeling both familiar and deeply unsettling." +
            "\n\nCats have nine lives... but you suddenly realize this isn’t your first brush with death.");
        if (cat.Lives < 1)
        {
            Console.WriteLine("Nine lives, and you’ve spent them all. Shadows close in once more — but this time, " +
                              "there is no return.");
            cat.Status = cat.Dead;
            cat.NotEscapedCastle = false;
            return;
        }

        Console.WriteLine(
            $"You’ve already lost {9 - cat.Lives}. That leaves only {cat.Lives} more chances. {cat.Lives} more lives " +
            $"to escape this cursed castle before the darkness takes you for good." +
            $"\n\nA choice stands before you:" +
            $"\n\n1. Revive in the room you first woke in and try again to escape." +
            $"\n2. Accept defeat and let the darkness claim you. (End Game.)" +
            $"\n\nWhat will you do?... \n");
        if (cat.UserChoice() == "1")
        {
            MainRoom.SubsequentWakeUp(cat, backPack);
        }
        else
        {
            cat.Status = cat.Dead;
            cat.NotEscapedCastle = false;
        }
    }

    static void OutsideCastle(Characters cat, BackPack backPack)
    {
        Console.WriteLine("\n\nWritten from MAIN STORY You got outside the castle ");
        // @add words about being outside but then running into a guard
        //@add EncounterWithGuard();
        cat.NotEscapedCastle = false;
    }

    static void ThirdFloor(Characters cat, BackPack backPack)
    {
        Console.WriteLine(
            "MAIN STORY TEXT you got out to the third floor!!"); // @add this is where you head off to the third floor
        cat.Status = "outside castle";
    }

    static void SuccessfulEscape()
    {
        Console.WriteLine( //@add rework this
            "The terrain ahead is dark and shrouded in mist, but already the oppressive atmosphere of");
        Console.WriteLine("the castle begins to lift. You've escaped—and you silently thank your lucky stars");
        Console.WriteLine("for it. As you stand there, the cold fog wrapping around you, you realize the path");
        Console.WriteLine("home is unclear.");
        Console.WriteLine("For now, the only thing that matters is that you are free.");
        Console.WriteLine("The journey ahead may be uncertain, but one thing is sure: you've survived the night.");
        Console.WriteLine("\n   >   >   >   >   >   >   >   >   =^.^=   <   <   <   <   <   <   <   <   <   \n");
        Console.WriteLine("Please press any key to continue...");
        Console.ReadKey();
=======
        Fight fight = new Fight(); // @fix move this to later when needed

        mainRoom.Intro();
        mainRoom.FirstWakeUp(cat.Name);
        mainRoom.StartInRoom();
        FirstRoomChoices(mainRoom, backPack, fight);
        
>>>>>>> testing
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