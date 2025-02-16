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

        mainRoom.RunMainRoom(cat, backPack, fight);

        foreach (string item in backPack.Pack)
        {
            Console.WriteLine(item);
        }
        
    }
}