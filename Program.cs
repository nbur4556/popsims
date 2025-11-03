Simulation simulation = new Simulation();
simulation.SetGenerations(args);
simulation.SetEntities(args);
simulation.Run();

public class Simulation
{
    private int generations = 1;
    private int entities = 0;

    public void Run()
    {
        for (int i = 0; i < generations; i++)
        {
            this.RunGeneration(i + 1);
        }
    }

    public void SetGenerations(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Error: No argument for generations provided.");
            return;
        }

        try
        {
            generations = int.Parse(args[1]);
        }
        catch
        {
            Console.WriteLine($"Error: Unable to parse {args[1]} to int for generations.");
        }
    }

    public void SetEntities(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Error: No argument for entities provided.");
            return;
        }

        try
        {
            entities = int.Parse(args[0]);
        }
        catch
        {
            Console.WriteLine($"Error: Unable to parse {args[0]} to int for entities.");
        }

    }

    private void RunGeneration(int currentGeneration)
    {
        int totalChildren = 0;
        int totalFemale = 0;
        for (int j = 0; j < entities; j++)
        {
            Entity entity = new Entity();
            if (entity.isFemale)
            {
                totalFemale++;
            }
            totalChildren += entity.childCount;
        }

        Console.WriteLine($"Generation: {currentGeneration}");
        Console.WriteLine($"Total Female: {totalFemale}");
        Console.WriteLine($"Total Male: {entities - totalFemale}");
        Console.WriteLine($"Total Children: {totalChildren}");
        Console.WriteLine("_____");
        entities = totalChildren;
    }
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
