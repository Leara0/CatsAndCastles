namespace CatsAndCastles;

public class Fight
{
    //@add if you have between 10 and 20 gold coins and bribe guard the cost must be the entire amount so your total GC doesn't fall under 10 (can't parse properly)
    //@add could add it thing that makes amounts less than 10 read as '05' etc
    Weapons _weapons = new Weapons();
    BackPack _backpack = new BackPack();

    public int RollDie(int numOfSides)
    {
        var random = new Random();
        return random.Next(0, numOfSides + 1);
    }
    /*As you move through the castle, the air grows tense. A low, rumbling growl breaks the silence—you're not alone.
        A guard dog stands before you, its eyes locked onto you with unwavering focus. Its muscles are tensed, ready to strike. There’s no escaping this fight—you’ll have to stand your ground.
        .*/

    public string ChooseWeapon(string[] inventory)
    {
        Console.WriteLine("You quickly check your inventory, assessing what you have and what might help you in " +
                          "battle?\n");
        if (_backpack.NumberOfItemsInPack() == 0)
        {
            Console.WriteLine("Your pack is empty. Your only choice is to fight with your paws: D4 +0");
            return "paws";
        }

        for (int i = 0; i < inventory.Length; i++) // shows inventory with weapons modifiers
        {
            if (inventory[i] == "")
                inventory[i] = "empty";
            int[] weaponStats = _weapons.WeaponChoice(inventory[i]);
            Console.WriteLine($"{i + 1} - {inventory[i]}: D{weaponStats[0]} +{weaponStats[1]}");
        }
        Console.WriteLine("\nChoose your weapon wisely. Enter the number of the item you wish to wield in this fight.");
        
        int response = int.Parse(_backpack.UserChoice(inventory.Length));
        if (inventory[response - 1] == "empty")
        {
            Console.WriteLine("You chose nothing. You will now fight with your paws: D4 +0");
            return "paws";
        }
        return inventory[response-1];
        

        return inventory[0];
    }

    //@add At start of story Cat needs health
    //@add falling out window takes a life. hitting head with shield/stone only takes health

    // in other location there will be story about encountering a bad guy(BG) 
    //there will be a chance to bribe the guard (deal with this in backpack methods)
    //if there's a fight the BG needs a health and weapon (modifier = 1 less? die = 1 less?)
    //the player must search inventory and choose a weapon (affects die and modifier)
    // then the fighting begins
    // player rolls die based on weapon and does damage
    // BG takes damage and updates health - checks for death
    // BG rolls and does damage
    // player takes damage and updates health - check for death
    // those 4 steps continue until one player dies

    //** someday add in healing elixirs??
}