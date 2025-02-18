namespace CatsAndCastles;

public class ThirdFloor
{
    //@add At start of story Cat needs health
    //@add falling out window takes a life. hitting head with shield/stone only takes health

    public void ThirdFloorStory(Characters cat, BackPack backPack)
    {/*As you move through the castle, the air grows tense. A low, rumbling growl breaks the silence—you're not alone.
        A guard dog stands before you, its eyes locked onto you with unwavering focus. Its muscles are tensed, ready to strike. There’s no escaping this fight—you’ll have to stand your ground.
        .*/
        Console.WriteLine("You slip out of the room, into a dimly lit hallway. It’s short and narrow, with three " +
                          "doors to your right, one slightly ajar. The stairway to your left leads downward, offering " +
                          "a potential escape—but the air is thick with uncertainty.");
        ThirdFloorGuardDog(cat, backPack);
        if (cat.Status == "second floor")
            return; // exits this class if the cat runs stright to the second floor
    }

    public void ThirdFloorGuardDog(Characters cat, BackPack backPack)
    {
        Fight fight = new Fight();

        Characters guardDog1 = new Characters();
        Random rnd = new Random();
        guardDog1.Health = rnd.Next(18, 23);
        cat.BeingChased = false;

        Console.WriteLine("\nAhead of you, standing still in the shadows, is a guard dog.  Its back is turned, and " +
                          "its gaze seems fixed on something further down the hall, unaware of your presence—at " +
                          "least for now." +
                          "\n\nYou realize that investigating the other doors would be risky with the guard dog so " +
                          "close. You’ll likely need to deal with it before you can safely explore the hallway. " +
                          "The doors might hold supplies or riches—things that could help in your escape, " +
                          "but first, you’ll have to decide how to approach the immediate threat." +
                          "\n\nYou have only moments to decide:" +
                          "\nPress '1' to engage the guard dog." +
                          "\nPress '2' to flee down the stairs and hope to outrun the threat.");
        switch (backPack.UserChoice())
        {
            case "1":
                EngageDog(cat, backPack, guardDog1);
                break;
            case "2":
                cat.Status = "second floor";
                cat.BeingChased = true; // need to find a way to mark cat as being chased without MORE variables!!
                break;
        }
    }

    public void EngageDog(Characters cat, BackPack backPack, Characters guardDog1)
    {
        Fight fight = new Fight();
        var hasGold = false;
        
        Console.WriteLine("You’re sure the dog won’t allow you to pass peacefully. Its eyes are locked onto you, " +
                          "full of menace, and it’s not about to let you slip by without a fight." +
                          "\n\nIf you want to explore the other rooms and continue your escape, you know you must " +
                          "deal with the dog.");
        
        foreach(string item in backPack.Pack)
            if (item.Contains("gold"))
                hasGold = true;
            
        if (hasGold)
        {
            Console.WriteLine("\nYou remember the gold coins in your pack. You could try to bribe the guard, " +
                              "offering the coins in hopes it will ignore your presence and let you go. " +
                              "It might work, but there’s no guarantee—this is no ordinary animal." +
                              "\n\nPress '1' to attempt to bribe the dog so it will turn a blind eye as " +
                              "you explore the floor" +
                              "\nPress '2' to prepare to engage in combat and face them head-on?\");");
            if (backPack.UserChoice() == "1")
                fight.Bribe(); //@fix this method
            else
                fight.Combat(cat, guardDog1, backPack);
        }
        else
        {
            Console.WriteLine("You prepare to engage in combat with the guard dog\n");
            fight.Combat(cat, guardDog1, backPack);
        }
    }
/* thrid floor story outline:
 - in the hall encounters a guard (can bribe, run or fight - if run must keep running all the way out of the castle (no other exploring) and still might get caught)
 - after guard is dispatched:
   - can rob guard's body (money, weapon (option if guard used paws??), third item??)
   - 3 doors (1 locked)
        + one room has - $, $, dagger
        + one room has - $, trinket, manacles? or ??

*/

    //** someday add in healing elixirs??
}