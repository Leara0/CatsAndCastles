namespace CatsAndCastles;

public class Fight
{
    //@add if you have between 10 and 20 gold coins and bribe guard the cost must be the entire amount so your total GC doesn't fall under 10 (can't parse properly)
    //@add could add it thing that makes amounts less than 10 read as '05' etc
    Weapons weapon = new Weapons();

    public int RollDie(int numOfSides)
    {
        var random = new Random();
        return random.Next(0, numOfSides + 1);
    }
    


    public void Bribe()
    {
    }

    public void Combat(Characters cat, Characters guardDog, BackPack backPack)
    {
        Random rnd = new Random();
        

        string[] weaponAndShield = ChooseWeapon(backPack);
        cat.Weapon = weaponAndShield[0];
        if (weaponAndShield[1] == "1")
            cat.HasShield = true;

        guardDog.Weapon = ChooseGuardDogWeapon();
        if (rnd.Next(1, 11) > 8)
            guardDog.HasShield = true;
        else
            guardDog.HasShield = false;
        // cat and guardDog have Health and Weapons

        Console.WriteLine("The moment for hesitation has passed. You’ve chosen your weapon — or perhaps you trust " +
                          "in your claws alone. Either way, there is no turning back." +
                          "\n\nThe guard dog snarls, its stance low and ready to strike. You had the chance to " +
                          "flee, to bargain, to avoid this fight, but you made your choice. Now, it's just you " +
                          "and the beast, locked in a battle for survival." +
                          "\n\nThe air is thick with tension. The dog’s muscles bunch, its eyes locked onto you. " +
                          "The fight is about to begin."); 

        WeaponsReminder(cat, "cat");
        WeaponsReminder(guardDog, "guardDog");
        Console.WriteLine();

        var caughtWhileRunningAway = false; //@add use this to add in running away 'extra function'
        //if 'caught' then the guard will attack first

        do
        {
            var attack = Attack(cat, rnd);
            guardDog.Health -= attack;
            Console.WriteLine($"You attack doing {attack} damage.");
            if (guardDog.HasShield)
                guardDog.Health++;
            if (guardDog.Health <= 0)
            {
                Console.WriteLine("\nYou are victorious in the fight against this guard dog");
                return;
            }

            attack = Attack(guardDog, rnd);
            cat.Health -= attack;
            Console.Write($"\nThe guard dog attacks you doing {attack} damage. ");
            if (cat.HasShield)
            {
                Console.Write("Your shield deflects 1 damage");
                cat.Health++;
            }

            Console.WriteLine($"\nYour remaining health is {(cat.Health >= 0 ? cat.Health : "0")} out of 60");
            if (cat.Health > 0)
            {
                Console.WriteLine("Please press 'enter' to continue.");
                Console.ReadLine();
            }
        } while (cat.Health > 0);

        if (cat.Health <= 0)
        {
            cat.Status = cat.PassedOut;
        }
    }

    public int Attack(Characters attacker, Random rnd)
    {
        int[] weaponStats = weapon.WeaponChoice(attacker.Weapon);
        return rnd.Next(1, weaponStats[0] + 1) + weaponStats[1];
    }

    public void WeaponsReminder(Characters attacker, string animalType)
    {
        int[] weaponStats = weapon.WeaponChoice(attacker.Weapon);
        Console.WriteLine(
            $"\n{(animalType == "cat" ? "You" : "The guard dog")} will be fighting with {attacker.Weapon} - D{weaponStats[0]} +{weaponStats[1]}");
        Console.WriteLine(
            $"{(animalType == "cat" ? "You" : "The guard dog")} will{(attacker.HasShield ? "" : " not")} be using a shield {(attacker.HasShield ? "(+1 protection)" : "")}");
    }

    public string ChooseGuardDogWeapon()
    {
        Random rnd = new Random();
        var dogWeapon = rnd.Next(1, 5);
        switch (dogWeapon)
        {
            case 1:
                return "manacles";
            case 2:
                return "a club";
            case 3:
                return "a bone";
            default:
                return "paws";
        }
    }

    public string[] ChooseWeapon(BackPack backPack)
    {
        Console.WriteLine("You quickly check your inventory, assessing what you have and what might help you in " +
                          "battle?\n");
        if (backPack.NumberOfItemsInPack() == 0)
        {
            Console.WriteLine("Your pack is empty. Your only choice is to fight with your paws: D4 +0");
            return ["paws", ""];
        }

        for (int i = 0; i < backPack.Pack.Length; i++) // shows inventory with weapons modifiers
        {
            if (backPack.Pack[i] == "")
                backPack.Pack[i] = "empty";
            int[] weaponStats = weapon.WeaponChoice(backPack.Pack[i]);
            Console.WriteLine($"{i + 1} - {backPack.Pack[i]}: D{weaponStats[0]} +{weaponStats[1]}");
        }

        Console.WriteLine("\nChoose your weapon wisely. Enter the number of the item you wish to wield in this fight.");

        int response = int.Parse(backPack.UserChoice(backPack.Pack.Length));
        string choice = backPack.Pack[response - 1];

        if (backPack.Pack[response - 1] == "empty")
        {
            Console.WriteLine("You chose nothing. You will now fight with your paws: D4 +0");
            choice = "paws";
        }

        var hasShield = "";
        if (backPack.Pack.Contains("the shield"))
        {
            Console.WriteLine("\nYour pack holds a shield — it would offer +1 protection in this fight, but its " +
                              "weight might slow you down, making you less agile. Do you want to use it in this fight?");
            Console.WriteLine("\nPlease press '1' if you'd like to use the shield and '2' to fight without it");
            if (backPack.UserChoice() == "1")
                hasShield = "1";
        }

        return [choice, hasShield];
    }
}