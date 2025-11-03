if (args.Length < 1)
{
    Console.WriteLine("Error: No argument provided for entityCount");
    return;
}

int genCount = 1;
if (args.Length > 1)
{
    try
    {
        genCount = int.Parse(args[1]);
    }
    catch
    {
        Console.WriteLine($"Error: Unable to parse {args[1]} to int. Running 1 generation.");
    }
}

int entityCount = 0;
try
{
    entityCount = int.Parse(args[0]);
}
catch
{
    Console.WriteLine($"Error: Unable to parse {args[0]} to int.");
    return;
}

for (int i = 0; i < genCount; i++)
{

    int totalChildren = 0;
    int totalFemale = 0;
    for (int j = 0; j < entityCount; j++)
    {
        Entity entity = new Entity();
        if (entity.isFemale)
        {
            totalFemale++;
        }
        totalChildren += entity.childCount;
    }

    Console.WriteLine($"Generation: {i + 1}");
    Console.WriteLine($"Total Female: {totalFemale}");
    Console.WriteLine($"Total Male: {entityCount - totalFemale}");
    Console.WriteLine($"Total Children: {totalChildren}");
    Console.WriteLine("_____");
    entityCount = totalChildren;
}

public class Entity
{
    public bool isFemale { get; private set; }
    public int maxAge { get; private set; }
    public int childCount { get; private set; }

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
