int entityCount = 24;
int totalChildren = 0;
for (int i = 0; i < 18; i++)
{
    Entity entity = new Entity();
    Console.WriteLine($"{i}: {entity.StatDescription()}");
    totalChildren += entity.childCount;
}

Console.WriteLine($"Total Children: {totalChildren}");

public class Entity
{
    public bool isFemale {get; private set;}
    public int maxAge {get; private set;}
    public int childCount {get; private set;}

    // TODO: The numbers should always equal 100
    // The chances of having X amount of children
    private int[] childCountDistribution;

    public Entity()
    {
        Random rand = new Random();
        childCountDistribution = new int[] { 10, 10, 26, 25, 29 };

        isFemale = rand.Next(2) == 0;
        maxAge = rand.Next(100);
        childCount = 0;

        if (maxAge > 18 && isFemale == true)
        {
            int chance = rand.Next(100);
            for (int i = 0; i < childCountDistribution.Count(); i++)
            {
                if (childCountDistribution[i] > chance)
                {
                    childCount = i;
                    break;
                }
                else
                {
                    chance -= childCountDistribution[i];
                }
            }
        }
    }

    public String StatDescription()
    {
        return $@"[isFemale: {isFemale}, maxAge: {maxAge}, childCount: {childCount}]";
    }
}
