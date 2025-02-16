namespace CatsAndCastles;

public class MainRoom
{
    public static string UserChoice(int numberOfOptions = 2)
    {
        do
        {
            string input = Console.ReadLine();
            for (int i = 1; i <= numberOfOptions; i++)
            {
                string iNumber = i.ToString();
                if (iNumber == input)
                {
                    Console.Clear();
                    return input;
                }
            }

            Console.WriteLine("I'm sorry, but that isn't a valid choice. ");
            Console.WriteLine("Please enter a number that corresponds with options above.");
        } while (true);
    }

    public void RunMainRoom()// I need to return items in backpack, cat name, Discarded items and List of AllPickedUpItems
    {
        Console.Clear();
        Characters cat = new Characters();
        cat.Name = cat.GetName();
        BackPack backPack = new BackPack();
        backPack.Pack = new string[5]; // creates a new pack that holds 5 items 
        backPack.DiscardedItems = new List<string>(); // create a record of all items that have been discarded 
        backPack.ListOfAllItemsPickedUp = new List<string>(); //keep track of all items that have been picked up 
        Fight fight = new Fight();
        
        for (int i = 0; i < backPack.Pack.Length; i++) // fills back with "" for later checks 
        {
            backPack.Pack[i] = "";
        }
 
        StoryTime(cat.Name);

        void StoryTime(string name)
        {
            Console.Clear();
            Console.WriteLine("\n   >   >   >   >   >   >   >   >   =^.^=   <   <   <   <   <   <   <   <   <   \n");
            Console.WriteLine(
                "Greetings, adventurer. The night has been long and unkind, and your memories of it are ");
            Console.WriteLine("little more than a haze.");
            

            FirstWakeUp(name);
        }

        void FirstWakeUp(string name)
        {
            Console.WriteLine("You wake, dazed and disoriented, your senses slow to return as you instinctively ");
            Console.WriteLine($"groom your soft coat. You feel a collar around your neck and notice a tag ");
            Console.WriteLine($"with the name \"{name}\" attached. Hmmmm, that name seems faintly familiar? Is it ");
            Console.WriteLine(
                "yours? A loved one's? The answer alludes you. You notice you still have your pack that can ");
            Console.WriteLine("hold 5 items, however, your spirits drop even lower as you realize it is empty. ");
            StartInRoom();
        }

        void SubsequentWakeUp()
        {
            Console.WriteLine("You wake, dazed and disoriented, your senses slow to return. ");
            StartInRoom();
        }

        void StartInRoom()
        {
            Console.WriteLine("The air is damp and heavy, thick with the scent of old stone and");
            Console.WriteLine("something faintly metallic. A chill clings to your fur, creeping in from the cold");
            Console.WriteLine("stone floor beneath you. The dim light from a single flickering torch casts long,");
            Console.WriteLine("wavering shadows across the chamber, making the jagged cracks in the walls seem");
            Console.WriteLine("to shift and writhe");
            Console.WriteLine("The hairs along your spine bristle. Something about this place feels wrong,");
            Console.WriteLine("as though unseen eyes watch from the darkness, waiting.");
            Console.WriteLine("You must escape but are unsure where to begin.");
            Console.WriteLine("Press 'enter' to continue.");
            Console.WriteLine("\n   >   >   >   >   >   >   >   >   =^.^=   <   <   <   <   <   <   <   <   <   \n");
            Console.ReadLine();
            FirstRoomChoices();
        }

        void FirstRoomChoices()
        {
            Console.Clear();
            Console.WriteLine("\n   <   <   <   <   <   <   <   <   =^.^=   >   >   >   >   >   >   >   >   >   \n");
            Console.WriteLine("Your eyes scan the room, taking in the details of your surroundings."
                              + " \n\nA few places stand out, each offering a chance to learn more:");
            Console.WriteLine("\n1 - A heavy wooden door, its iron hinges rusted with age.");
            Console.WriteLine("2 - A second smaller wooden door, it looks as if it has seen little use.");
            Console.WriteLine("3 - A window, just high enough to reach with a careful leap.");
            Console.WriteLine("4 - The nightstand, small but perhaps hiding something useful.");
            Console.WriteLine("5 - The bookshelf, mostly bare, its empty shelves coated in dust.");
            Console.WriteLine("6 - A large stone hearth, cold and imposing");
            Console.WriteLine("7 - Your pack. You can inspect the contents and discard ones you no longer want");
            if (backPack.DiscardedItems.Count == 1)
            {
                Console.WriteLine("8 - An item you’ve chosen to discard—perhaps too hastily. " +
                                  "If you've changed your mind, you can return to the pile and reclaim it..");
            }

            if (backPack.DiscardedItems.Count > 1)
            {
                Console.WriteLine("8 - A heap of items you’ve chosen to discard—perhaps too hastily. " +
                                  "If you've changed your mind, you can return to the pile and reclaim items..");
            }
            Console.WriteLine("9 - Check out how strong your inventory items would be in a fight");//@fix remove this 

            Console.WriteLine("\nWhere would you like to explore?");
            Console.WriteLine("Please press the number corresponding with your choice.");
            Console.WriteLine("\n   <   <   <   <   <   <   <   <   =^.^=   >   >   >   >   >   >   >   >   >   \n");

            switch (UserChoice(9))//@fix adjust this after removing 9
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
                    while (UserChoice() == "1")
                    {
                        backPack.RemoveItemsFromPack();
                        backPack.ListContentsOfPack();
                        Console.WriteLine("Would you like to remove another item?" +
                                          "\n Press '1' to remove another item and '2' to continue exploring the room");
                    }

                    FirstRoomChoices();
                    break;
                case "8":
                    backPack.PickUpItemsFromDiscarded();
                    FirstRoomChoices();
                    return; //@fix is this the right thing here?
                case "9":
                    string choice = fight.ChooseWeapon(backPack.Pack);
                    Console.WriteLine($"You chose {choice}");
                    Console.WriteLine("Press 'enter'");
                    Console.ReadLine();
                    FirstRoomChoices();
                    break;
            }
        }

        void ReturnToMainPartOfRoom(string fromLocation)
        {
            Console.WriteLine(
                $"You step away from the {fromLocation}{(fromLocation == "closet" ? "and shut the door behind you" : "")}.");
            FirstRoomChoices();
        }

        void ListItemsInLocation(string location)
        {
            backPack.AssignItemsBasedOnLocation(location);
            for (int i = 0; i < backPack.Options.Length; i++)
            {
                if (backPack.ListOfAllItemsPickedUp.Contains(backPack.Options[i]))
                    backPack.Descriptions[i] = backPack.emptySpot;
                Console.WriteLine($"- {backPack.Descriptions[i]}");
            }
        }

        void DecisionTime(string location)
        {
            Console.WriteLine("Please press '1' if you'd like to take some items with you and '2' if you'd like to ");
            Console.WriteLine("leave all the items untouched.");

            if (UserChoice() == "1")
                backPack.TakeItems(location);
            ReturnToMainPartOfRoom(location);
        }

        void ExploreNightStand()
        {
            Console.WriteLine("Your eyes land on the nightstand—a small, unassuming piece of " +
                              "furniture beside the cushion where you first woke up. Its surface " +
                              "is scratched, its single drawer slightly ajar, as if someone once " +
                              "meant to close it but never quite did." +
                              "\n\nInside, you find:");
            ListItemsInLocation("nightstand");
            Console.WriteLine("\nThe drawer holds no more secrets, only the question of whether " +
                              "any of these things might be useful to you." +
                              "\n\nWould you like to take anything?");
            DecisionTime("nightstand");
        }

        void ExploreCloset()
        {
            Console.WriteLine("You move toward the small door on the opposite wall, its wood worn and cracked. " +
                              "It creaks loudly as you push it open, revealing a narrow, dim space." +
                              "Upon stepping inside, you realize this is a closet. The air is stale, thick with dust." +
                              "\n\nThe shelves are cluttered with the following items:");
            ListItemsInLocation("closet");
            Console.WriteLine("\nThis space hasn't been used in a long time—and whatever it was used for " +
                              "doesn't seem welcoming. \n\nWould you like to take anything?");
            DecisionTime("closet");
        }

        void ExploreBookshelf()
        {
            Console.WriteLine("You approach the bookshelf, your paws silent against the cold floor. " +
                              "It stands tall against the wall, its once-polished wood " +
                              "now dull and splintered. Most of the shelves are bare, coated in dust thick enough " +
                              "to leave tracks." +
                              "\n\nScanning the empty spaces, your eyes catch a few forgotten objects:");
            ListItemsInLocation("bookshelf");
            Console.WriteLine("\nThe air here is still, as though these objects have been waiting undisturbed for a " +
                              "long time.\n\nWould you like to take anything with you?");
            DecisionTime("bookshelf");
        }


        void ExploreHearth()
        {
            Console.WriteLine("Your gaze drifts to the hearth—large and cold, its once-grand stonework now " +
                              "stained with time. \n\nAs you step closer, your paws stir the dust, revealing " +
                              "forgotten things among the ashes and shadows:");
            ListItemsInLocation("hearth");
            Console.WriteLine("Would you like to take anything?");
            DecisionTime("hearth");
        }


        void ExploreWindow()
        {
            Console.Clear();
            Console.WriteLine(
                "\n   -   -   -   -   -   -   -   -   =^.^=   -   -   -   -   -   -   -   -   -   -   \n");
            Console.WriteLine("You move toward the window, and as you draw closer, the suffocating weight of");
            Console.WriteLine("the castle's gloom seems to ease—if only slightly. Springing forward you leap");
            Console.WriteLine(
                "onto the sill and peer outside. Below, the ground looms a daunting thirty or more feet");
            Console.WriteLine(
                "down, bathed in the pale glow of the moon. A fall from this height would be dangerous,");
            Console.WriteLine("but not impossible.");
            Console.WriteLine("Your muscles tense as you consider your options. ");
            Console.WriteLine(
                "You could take the leap, relying on your feline agility and luck to land safely. Or you could " +
                "check your inventory for other options to assist you in climbing down. " +
                "The eerie stillness of the castle gnaws at your nerves, urging you to act quickly." +
                "\nPress '1' to check your inventory and '2' to leap down and '3' to continue exploring the room");
            switch (UserChoice(3))
            {
                case "1":
                    foreach (var item in backPack.Pack) //if you have sheets you can choose to use them
                    {
                        if (item == "faded bed sheets")
                        {
                            Console.WriteLine(
                                "You find a pile of old sheets in your inventory. You realize they could be tied " +
                                "together to make a rope to assist you in climbing down. " +
                                "\nPress '1' to use the sheets to assist you, '2' to choose to leap down and '" +
                                "3' to continue exploring other areas in the room.");
                            //@fix Console.WriteLine(
                            // @fix "\n   -   -   -   -   -   -   -   -   =^.^=   -   -   -   -   -   -   -   -   -   -   \n");
                            switch (UserChoice(3))
                            {
                                case "1":
                                    UseSheets();
                                    return;
                                case "2":
                                    JumpDown();
                                    return;
                                case "3":
                                    ReturnToMainPartOfRoom("door");
                                    return;
                            }
                        }
                        else
                        {
                            Console.WriteLine(
                                "You don't find any items in your inventory that could be of assistance. " +
                                "The eerie stillness of the castle gnaws at your nerves, urging you to act quickly." + //@fix repetitive text
                                "\nHow will you proceed?" +
                                "\nPlease press '1' to choose to leap down and '2' to continue exploring other areas in the room.");
                            Console.WriteLine(
                                "\n   -   -   -   -   -   -   -   -   =^.^=   -   -   -   -   -   -   -   -   -   -   \n");
                            if (UserChoice(2) == "1")
                                JumpDown();
                            else
                                ReturnToMainPartOfRoom("door");
                        }
                    }

                    return;
                case "2":
                    JumpDown();
                    break;
                case "3":
                    ReturnToMainPartOfRoom("door");
                    break;
            }
        }

        void JumpDown()
        {
            Console.WriteLine("\n   >   >   >   >   >   >   >   >   =^.^=   <   <   <   <   <   <   <   <   <   \n");
            Console.WriteLine("you take a deep breath and leap into the night, trusting your agility. For a brief");
            Console.WriteLine("moment, you feel weightless—until you land with a jarring thud. The ground is");
            Console.WriteLine(
                "unforgiving, and your 4 legs give way beneath you and your head smacks against the hard earth.");
            PassOut();
        }

        void PassOut()
        {
            Console.WriteLine(
                "The pain is immediate and blinding, and the world tilts around you, fading to black... =x.x=\n");
            Console.WriteLine("Please press 'enter' to continue.");
            Console.ReadLine();
            SubsequentWakeUp();
        }

        void UseSheets()
        {
            Console.WriteLine(
                "\n   >   >   >   >   >   >   >   >   =^.^=   <   <   <   <   <   <   <   <   <   \n");
            Console.WriteLine(
                "You reach into your pack and withdraw the worn but sturdy bed sheets. Working quickly, " +
                "you tie them together, each knot pulled tight between your claws. You find a solid " +
                "anchor—an iron ring embedded in the wall—and loop the sheets securely around it. " +
                "With a final, cautious tug, you toss the bundle out the window. It unfurls, swaying " +
                "slightly in the breeze, a lifeline into the unknown. " +
                "The cold night air nips at your skin as you climb down, each movement measured and deliberate.");
            Console.WriteLine("At last, your feet touch the ground—rough soil beneath you, a welcome change");
            Console.WriteLine("from the damp stone. ");
            OutsideCastle();
        }

        void OutsideCastle()
        {
            // @add words about being outside but then running into a guard
            //@add EncounterWithGuard();
        }

        void SuccessfulEscape()
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
        }


        void ExploreDoor() //@add revisit this
        {
            Console.WriteLine(
                "\n   -   -   -   -   -   -   -   -   =^.^=   -   -   -   -   -   -   -   -   -   -   \n");
            Console.WriteLine(
                "You approach the heavy wooden door, its frame dark and imposing against the stone wall." +
                "Your eyes are drawn to the thick, old lock hanging from the latch. " +
                "The lock looks sturdy, its cold metal catching the dim light. It's a formidable obstacle, " +
                "preventing you from escaping. . , but you know you must find a way out. " +
                "Would you like to search your inventory for tools or items that might aid in unlocking the door " +
                "or continue exploring the room?");
            Console.WriteLine("Please press '1' to search your inventory and '2' to return to exploring the room");
            if (UserChoice() == "1")
                AttemptToUnlockDoor();
            else
                ReturnToMainPartOfRoom("door");
        }

        void AttemptToUnlockDoor() //@fix there must be a way to make the stone vs shield thing shorter
        {
            var hasLockPick = false;
            var hasStone = false;
            var hasShield = false;

            foreach (var item in backPack.Pack)
            {
                if (item == "the rusted set of tools")
                    hasLockPick = true;
                if (item == "the large stone")
                    hasStone = true;
                if (item == "the shield")
                    hasShield = true;
            }

            if (hasLockPick && (hasStone || hasShield))
            {
                Console.WriteLine("You pause and take a moment to look through your inventory, searching for " +
                                  "something that might help. Your paws sift through the items you’ve collected so " +
                                  "far, and you find two items that might be useful:" +
                                  "\n- A rusted set of tools—small, delicate rods and a hook that might be able to " +
                                  "fit into the lock, though they look far from reliable.");
                if (hasStone)
                    Console.WriteLine("- A heavy smooth rock, solid and weighty in your grasp. While not the most " +
                                      "subtle choice, it might be capable of smashing the lock off with a few good strikes.");
                if (hasShield)
                    Console.WriteLine("- A shield, its metal surface scratched and worn, but still sturdy. " +
                                      "It could be used to bash the lock off with brute force.");

                Console.WriteLine("\nThe options sit before you. You can:" +
                                  "\n'1' - Keep exploring the room, hoping for another way out or more supplies " +
                                  "that might help.");
                Console.WriteLine("'2' - Attempt to pick the lock with the rusted tools.");
                if (hasStone && hasShield)
                {
                    Console.WriteLine("'3' - Use the rock to smash the lock off.");
                    Console.WriteLine("'4' - Use the shield to smash the lock off.");
                }
                else if (hasStone)
                    Console.WriteLine("'3' - Use the rock to smash the lock off.");
                else if (hasShield)
                    Console.WriteLine("'3' - Use the shield to smash the lock off.");


                string response = UserChoice(4);
                switch (response)
                {
                    case "1":
                        ReturnToMainPartOfRoom("door");
                        break;
                    case "2":
                        PickLock();
                        break;
                    default:
                        if (hasStone && hasShield)
                            if (response == "3")
                                HeavyObject("stone");
                            else
                                HeavyObject("shield");
                        else if (hasShield)
                            HeavyObject("shield");
                        else
                            HeavyObject("stone");
                        break;
                }
            }

            else if (hasStone && hasShield)
            {
                Console.WriteLine("You pause and take a moment to look through your inventory, searching for " +
                                  "something that might help. Your paws sift through the items you’ve collected so " +
                                  "far, and you find two items that might be useful:" +
                                  "\n- A heavy smooth rock, solid and weighty in your grasp. While not the most" +
                                  "\nsubtle choice, it might be capable of smashing the lock off with a few good strikes." +
                                  "\n- A shield, its metal surface scratched and worn, but still sturdy. " +
                                  "It could be used to bash the lock off with brute force.");

                Console.WriteLine("\nThe options sit before you. You can:" +
                                  "\n'1' - Use the rock to bash the lock off." +
                                  "\n'2' - Use the shield to smash the lock off. " +
                                  "\n'3' - Keep exploring the room, hoping for another way out or more supplies that might help");
                switch (UserChoice(3))
                {
                    case "1":
                        HeavyObject("stone");
                        break;
                    case "2":
                        HeavyObject("shield");
                        break;
                    case "3":
                        ReturnToMainPartOfRoom("door");
                        break;
                }
            }

            else if (hasLockPick)
            {
                Console.WriteLine("You dig through your pack, your paws brushing over familiar items until you " +
                                  "feel something that might help. You pull out the rusted set of tools—small, " +
                                  "delicate rods of metal, a hook, and a flattened key-like piece. " +
                                  "Though worn and aged, they seem like they might fit together in some way. " +
                                  "\nWould you like to attempt to use them to pick the lock or would you like" +
                                  "to continue searching the room for other items that might help?"); //@fix this wording is awkward
                Console.WriteLine("\nPlease press '1' to try to pick the lock with the rusted tools and " +
                                  "'2' to return to exploring the room");
                Console.WriteLine(
                    "\n   -   -   -   -   -   -   -   -   =^.^=   -   -   -   -   -   -   -   -   -   -   \n");
                if (UserChoice() == "1")
                    PickLock();
                else
                    ReturnToMainPartOfRoom("door");
            }


            else if (hasShield)
            {
                Console.WriteLine("You dig through your pack, feeling the weight of each item, until your paw " +
                                  "brushes against something solid. You pull out the shield. " +
                                  "It feels solid in your grip, it might just be powerful enough to break the " +
                                  "lock off the door." +
                                  "\nThe lock seems secure, and the shield might be your only chance at forcing your way " +
                                  "through.");
                Console.WriteLine("Please press '1' to try to use the shield to break the lock and " +
                                  "'2' to return to exploring the room");
                if (UserChoice() == "1")
                    HeavyObject("shield");
                else
                    ReturnToMainPartOfRoom("door");
            }
            else if (hasStone)
            {
                Console.WriteLine("You dig through your pack, feeling the weight of each item, until your paw " +
                                  "brushes against something solid. You pull out a large stone, its surface smooth and " +
                                  "worn. It feels heavy in your grip, it might just be powerful enough to break the " +
                                  "lock off the door." +
                                  "\nThe lock seems secure, and the stone might be your only chance at forcing your way " +
                                  "through.");
                Console.WriteLine("Please press '1' to try to use the large stone to break the lock and " +
                                  "'2' to return to exploring the room");
                Console.WriteLine(
                    "\n   -   -   -   -   -   -   -   -   =^.^=   -   -   -   -   -   -   -   -   -   -   \n");
                if (UserChoice() == "1")
                    HeavyObject("stone");
                else
                    ReturnToMainPartOfRoom("door");
            }
            else
            {
                Console.WriteLine("You don't have any items in your inventory that can help you with the lock.");
                Console.WriteLine("You must continue to explore the room.");
                Console.WriteLine("Press 'enter' to continue");
                Console.ReadLine();
                ReturnToMainPartOfRoom("door");
            }
        }

        void HeavyObject(string objectName)
        {
            Console.WriteLine(
                "\n   >   >   >   >   >   >   >   >   >   =^.^=   <   <   <   <   <   <   <   <   <   \n");
            Console.WriteLine($"You decide to try your luck with the heavy {objectName}. With a grunt, you lift the");
            Console.WriteLine($"{objectName}, its weight heavy in your hands. You aim it carefully at the lock and");
            Console.WriteLine(
                $"swing with all your might. The {objectName} slams into the lock with a loud crack, but the");
            Console.WriteLine(
                $"force causes it to bounce off the door, sending the {objectName} ricocheting back toward");
            Console.WriteLine("you.");
            Console.WriteLine($"Before you can react, the {objectName} strikes your head with a sharp blow.");
            PassOut();
            SubsequentWakeUp();
        }

        void PickLock()
        {
            Console.WriteLine(
                "\n   >   >   >   >   >   >   >   >   >   =^.^=   <   <   <   <   <   <   <   <   <   \n");
            Console.WriteLine("You carefully examine the rusty set of tools. With steady hands,");
            Console.WriteLine("you select a small pick and a thin rod, using them to work the lock. The old lock");
            Console.WriteLine("resists at first, but with a soft click, it finally gives way.");
            Console.WriteLine("With a sigh of relief, you open the door slowly, careful not to make a sound.");
            /*Console.WriteLine("Beyond, a narrow spiral staircase winds down into the shadows. You step carefully,");
            Console.WriteLine("feeling the weight of the moment.");
            Console.WriteLine("As you near the bottom of the staircase, you notice a faint sliver of moonlight");
            Console.WriteLine("filtering through a door that's slightly open. The light cuts through the darkness");
            Console.WriteLine("like a beacon, guiding your way. With each step, the cold night air seems to draw");
            Console.WriteLine("closer. With a final glance behind you, you sneak out the door, your heart pounding ");
            Console.WriteLine("in your chest.");*/ //@fix rework this
            SuccessfulEscape();
        }

        
    }
}