using System.Runtime.CompilerServices;

namespace CatsAndCastles;

public class BackPack
{
    public string emptySpot = "a faint outline marking the spot where something once rested";
    public string[] Pack { get; set; } = new string[5];
    public List<string> DiscardedItems { get; set; } 

    public List<string>
        ListOfAllItemsPickedUp { get; set; } //use this to prevent player from picking up the same object multiple times

    public int Wallet { get; set; }
    
    
    

    public  string UserChoice(int numberOfOptions = 2)
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

    public int NumberOfItemsInPack() // counts how many items are in pack
    {
        var counter = 0;
        for (int i = 0; i < Pack.Length; i++)
        {
            if (Pack[i] != "")
            {
                counter++;
            }
        }

        return counter;
    }

    public void CheckPack() // tells user how many items are in pack and allows user to remove items if they want
    {
        var numOfItemsInPack = 0;
        var stopRemovingItems = false;
        do
        {
            numOfItemsInPack = NumberOfItemsInPack();
            Console.Write(
                $"\nYour pack currently contains {(numOfItemsInPack > 0 ? numOfItemsInPack + " items." : "nothing")}");

            if (numOfItemsInPack > 0)
            {
                Console.WriteLine("Would you like to remove anything from your pack?");
                Console.WriteLine("Please press '1' for yes and '2' for no.");
                if (UserChoice() == "1")
                {
                    RemoveItemsFromPack();
                }
                else
                    stopRemovingItems = true;
            }
            else
                stopRemovingItems = true;
        } while (!stopRemovingItems);
    }

    public void ListContentsOfPack()
    {
        Console.WriteLine("The contents of your pack are as follows:");
        for (int i = 0; i < Pack.Length; i++)
        {
            if (Pack[i] != "")
                Console.WriteLine($"  {i + 1} - {Pack[i]}");
            else
            {
                Console.WriteLine($"  {i + 1} - empty");
            }
        }
    }


    public void PickUpItemsFromDiscarded()
    {
        Console.WriteLine("Your discarded stash contains the following item/s:");
        for (int i = 0; i < DiscardedItems.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {DiscardedItems[i]}");
            
        }
        Console.WriteLine($"\nPlease type the number of the item you would like to pick up. " +
                          $"Or press {DiscardedItems.Count + 1} to return to exploring the room");

        int response = Convert.ToInt32(UserChoice(DiscardedItems.Count + 1));

        if (response < DiscardedItems.Count + 1)
        {
            AddItemToPack(DiscardedItems[response - 1]);
            DiscardedItems.RemoveAt(response - 1);
        }
    }

    public void RemoveItemsFromPack()
    {
        if (NumberOfItemsInPack() == 0)
        {
            Console.WriteLine("There are no items in your pack.");
            Console.WriteLine("Please 'enter' to continue");
            Console.ReadLine();
            return;
        }

        ListContentsOfPack();

        Console.WriteLine("Please enter the number of the item you would like to remove.");
        var numToRemove = int.Parse(UserChoice(5));
        var item = Pack[numToRemove - 1];

        if (item != "")
        {
            
            Console.WriteLine(
                $"You have removed {item} from your pack. It can now be found in your discard stash.");
            if (item.Contains("gold"))
                RemoveMoneyFromWallet(item);
            DiscardedItems.Add(item); // adds removed item to discarded list
            Pack[numToRemove - 1] = ""; //erases that item by replacing with ""
        }
        else
        {
            Console.WriteLine("There is nothing in this spot so nothing has been removed.");
        }

        Console.WriteLine("Please 'enter' to continue");
        Console.ReadLine();
    }

    public void RemoveMoneyFromWallet(string item)
    {
        int money = int.Parse(item.Substring(0, 2));
        Wallet -= money;
    }

    public string AddMoney(string item)
    {
        ListOfAllItemsPickedUp
            .Add(item);

        int money = int.Parse(item.Substring(0, 2));
        Wallet += money;

        if (Wallet < 10)
            item = "0" + Wallet + " gold coins";
        else
            item = Wallet + " gold coins";
        return item;
    }

    public void AddItemToPack(string item)
    {
        if (NumberOfItemsInPack() == 5)
        {
            Console.WriteLine("Your pack is too burdened to add any more items. You must remove" +
                              $" something to make space for {item}.");
            Console.WriteLine("Please press '1' to remove items and '2' to make no changes to your pack.");
            if (UserChoice() == "1")
                RemoveItemsFromPack();
            else
                return;
        }

        if (item == emptySpot)
        {
            Console.WriteLine("Nothing remains in this spot. Please make an alternate selection");
            Console.WriteLine("Press 'enter' to continue");
            Console.ReadLine();
            return;
        }

        if (item.Contains("coins"))
        {
            item = AddMoney(item);
        }

        bool goldAlreadyInPack = false;
        foreach (string thing in Pack)
        {
            if (thing.Contains("gold"))
                goldAlreadyInPack = true;
        }

        if (goldAlreadyInPack && item.Contains("gold"))
        {
            for (int i = 0; i < Pack.Length; i++) // then add it to an empty space in the pack
            {
                if (Pack[i].Contains("gold") && item.Contains("gold"))
                {
                    Pack[i] = item;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < Pack.Length; i++)
            {
                if (Pack[i] == "")
                {
                    Pack[i] = item;
                    break;
                }
            }
        }

        Console.WriteLine($"You pack now contains {item}");
        ListOfAllItemsPickedUp
            .Add(item); //and add the item to the list of all items that have been picked up
        Console.WriteLine("Press 'enter' to continue");
        Console.ReadLine();
        return;
    }

    public string[] Options = new string[3];
    public string[] Descriptions = new string[3];

    public void AssignItemsBasedOnLocation(string location)
    {
        switch (location)
        {
            case "closet":
                Options[0] = "faded bed sheets";
                Descriptions[0] = "Several folded bed sheets, their fabric yellowed but sturdy.";
                Options[1] = "the broom and dust pan";
                Descriptions[1] = "A broom and dustpan that lean against the far wall, unused for " +
                                  "what seems like years.";
                Options[2] = "manacles";
                Descriptions[2] = "A set of manacles, their chains coiled and rusted, almost blending into " +
                                  "the shadowy corner.";
                break;
            case "nightstand":
                Options[0] = "10 gold coins in the drawer";
                Descriptions[0] = "Ten gold coins, their surfaces dull with age but still carrying a " +
                                  "reassuring weight.";
                Options[1] = "a pair of glasses";
                Descriptions[1] = "A pair of glasses, their lenses smudged with dust, the frames bent slightly " +
                                  "out of shape.";
                Options[2] = "a book of prayers";
                Descriptions[2] = "A book of prayers, its leather cover cracked with age, the pages thin and delicate.";
                break;
            case "bookshelf":
                Options[0] = "the dagger";
                Descriptions[0] =
                    "A dagger, its handle wrapped in worn leather, the blade dull but still sharp enough to be dangerous.";
                Options[1] = "the rusted set of tools";
                Descriptions[1] = "A small, rusted set of tools—a few thin rods of metal, a hook, and something " +
                                  "resembling a flattened key. They seem out of place, their purpose unclear at " +
                                  "first, though their delicate shapes suggest they might fit into something " +
                                  "small and stubborn.";
                Options[2] = "the cat figurine";
                Descriptions[2] = "A wooden figurine, carved in the shape of a cat. It’s crude but detailed enough " +
                                  "to capture the curve of a tail and the prickle of carved fur along its back. " +
                                  "The eyes, once painted, have long since faded, leaving behind empty impressions in the wood.";
                break;
            case "hearth":
                Options[0] = "the fire poker";
                Descriptions[0] = "A fire poker, its iron worn smooth from years of use, still sturdy " +
                                  "enough to be a weapon or a tool.";
                Options[1] = "the large stone";
                Descriptions[1] = "A large, loose stone, sitting slightly askew among the others. Heavier than " +
                                  "it looks, it would be perfect for smashing something stubborn.";
                Options[2] = "the shield";
                Descriptions[2] = "A shield, nearly invisible at first, hidden beneath layers of dust and cobwebs. " +
                                  "Its metal is dulled, its emblem barely discernible, but it remains solid—built " +
                                  "to withstand blows.";
                break;
        }
    }

    public void TakeItems(string location)
    {
        AssignItemsBasedOnLocation(location);

        do
        {
            for (int i = 0; i < Options.Length; i++) // mark items that have already been picked up
            {
                if (ListOfAllItemsPickedUp.Contains(Options[i])) // 
                    Options[i] = emptySpot;
            }

            Console.WriteLine("\nPlease choose which items you would like to add to your pack:");

            for (int i = 0; i < Options.Length; i++)
                Console.WriteLine($"  {i + 1} - {Options[i]}");


            Console.WriteLine($"\n Or press '4' to leave the {location}. " +
                              $"Items that you have removed from your inventory can be found in the discard " +
                              $"stash in the main room.");

            
            switch (UserChoice(4))
            {
                case "1":
                    AddItemToPack(Options[0]);
                    break;
                case "2":
                    AddItemToPack(Options[1]);
                    break;
                case "3":
                    AddItemToPack(Options[2]);
                    break;
                case "4":
                    return;
            }
        } while (NumberOfItemsInPack() <= 5);
    }
}