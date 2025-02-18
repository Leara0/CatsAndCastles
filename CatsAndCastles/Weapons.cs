namespace CatsAndCastles;

public class Weapons
{
    public int[] WeaponChoice(string weapon)
    {
        int modifier = 0;
        int die = 0;
        switch (weapon) //@add consider adding more - maybe book of prayers has negative mod?
        {
            case "the broom and dust pan":
            case "the cat figurine":
                modifier = 1;
                die = 4;
                break;
            case "manacles":
                modifier = 2;
                die = 6;
                break;
            case "the dagger":
                modifier = 2;
                die = 8;
                break;
            case "a club":
            case "a bone":
            case "the fire poker":
                modifier = 2;
                die = 6;
                break;
            case "the large stone":
            case "the shield":
                modifier = 1;
                die = 6;
                break;
            case "empty":
                modifier = 0;
                die = 0;
                break;

            case "paws":
                modifier = 0;
                die = 4;
                break;
        }

        return [die, modifier];
    }

    public int DefenseChoice(string defense)
    {
        if (defense == "the shield")
            return 2;
        return 0;
    }
}