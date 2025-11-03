public class Simulation
{
    public bool live = true;
    private int generations = 1;
    private int generationsElapsed = 0;
    private int entities = 0;

    public void Run()
    {
        for (int i = 0; i < generations; i++)
        {
            this.RunGeneration();
        }

        Console.WriteLine("Continue? (y or generation #)");
        string? continueResponse = Console.ReadLine();
        if (continueResponse == null)
        {
            return;
        }
        if (continueResponse == "y" || continueResponse == "Y")
        {
            generations = 1;
        }
        else
        {
            try
            {
                generations = int.Parse(continueResponse);
            }
            catch
            {
                return;
            }
        }
        this.Run();
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

    private void RunGeneration()
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

        Console.WriteLine($"Generation: {++generationsElapsed}");
        Console.WriteLine($"Total Female: {totalFemale}");
        Console.WriteLine($"Total Male: {entities - totalFemale}");
        Console.WriteLine($"Total Children: {totalChildren}");
        Console.WriteLine("_____");
        entities = totalChildren;
    }
}
