namespace CatsAndCastles;

public class Characters
{
    public string Dead = "dead";
    public string ThirdFloor = "third floor";
    public string OutsideCastle = "outside castle";
    public string PassedOut = "passed out";
    
    
    public int Health { get; set; }
    public string Name { get; set; } = "";
    public string Weapon { get; set; } = "";
    public int Lives { get; set; } = 4;
    public string Status { get; set; } = "";// I'll use this to tell where the player is (passed out, third floor, second floor, first floor, outside castle)
    public bool NotEscapedCastle { get; set; } = true;
    public bool HasShield { get; set; }
    public bool BeingChased { get; set; } = false;

    public string UserChoice(int numberOfOptions = 2)
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
    public int SetHealth(int bottom, int top)
    {
        var rnd = new Random();
        return rnd.Next(bottom, top+1);
    }
    public  string GetName()
    {
        Console.WriteLine("What is your name (or a name you like)?");
        var name = Console.ReadLine();
        return char.ToUpper(name[0]) + name.Substring(1);
    }
    public string UserChoice(int numberOfOptions = 2)
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
}