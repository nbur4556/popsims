// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Entity
{

    private bool isFemale;

    public Entity()
    {
        var rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(rand.Next());
        }
    }
}
