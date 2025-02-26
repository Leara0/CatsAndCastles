namespace CatsAndCastles;

public class FirstFloor
{
    public void FirstFloorStory(Characters cat, BackPack backPack, Characters warden)
    {
        Console.WriteLine(
            "You descend the stairs, each step measured, each breath steady. As you reach the main floor, " +
            "the atmosphere shifts—heavy, charged, dangerous. The room before you is vast, its purpose " +
            "unclear, but there is no time to dwell on the details." +
            "\n\nBecause you are not alone.");
        if (warden.Location != Characters.Place.Dead && !cat.SuccessfulBribed)
            Fight.GuardDogEncounter(cat, backPack, warden, 2);
        // stuff here to wrap things up is you get past him
        if (warden.Location == Characters.Place.Dead || cat.SuccessfulBribed)
        {
            if (warden.Location == Characters.Place.Dead)
                Console.WriteLine(
                    "The battle was brutal. The Warden was relentless. You dodged, clawed, bit, and fought " +
                    "with everything you had. You felt the sting of death more than once, your vision fading " +
                    "to black before snapping back—another life spent, but not in vain." +
                    "\n\nNow, the Warden lies motionless, its massive form still, its armor dented and " +
                    "bloodied. You stand victorious. Your body aches, your breath comes ragged, " +
                    "but you are alive." +
                    "\n\nAnd then — you see it." +
                    "\n\n.");
            Console.WriteLine("Beyond the Warden’s fallen form, a door stands ajar. A whisper of wind drifts in, " +
                              "carrying scents of grass, damp earth, and freedom. The world beyond is still out of " +
                              "reach, but not for long. You stand at the threshold of the open door, the outside world " +
                              "beckoning you with its cool night air and the scent of freedom just beyond. But the " +
                              "castle calls to you too—its dim halls, its hidden rooms full of untold secrets. " +
                              "Perhaps there’s more you could find, something that could aid you in your journey " +
                              "into the unknown. You hesitate for a moment, torn between leaving the castle behind and " +
                              "venturing deeper into it");
            Console.WriteLine("Press '1' to leave the castle or '2' to return head back up the stairs and continue" +
                              "exploring the castle");
            if (cat.SuccessfulBribed)
                Console.WriteLine("Bear in mind, if you leave this floor the guard will expect another bribe or a " +
                                  "fight");
            if (backPack.UserChoice() == "1")
            {
                Console.WriteLine("\nYou stagger forward, each step pulling you away from the gloom of the castle, " +
                                  "away from the danger, away from death itself. One final push, and are free.");
                cat.Location = Characters.Place.OutsideCastle;
            }
            else
                cat.Location = Characters.Place.SecondFloor;
        }
        else if (cat.Location == Characters.Place.SecondFloor)
            return;
        else
        {
            cat.LostToGuard = true;
            cat.Location = Characters.Place.PassedOut;
        }
    }
}