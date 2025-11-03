Entity entity = new Entity();
Console.WriteLine(entity.StatDescription());

public class Entity
{
    private bool isFemale;
    private int maxAge;
    private int childCount;

    public Entity()
    {
        Random rand = new Random();

        isFemale = rand.Next(2) == 0;
        maxAge = rand.Next(100);
        childCount = 0;

        if (maxAge > 18 && isFemale == true)
        {
            childCount = rand.Next(5);
        }
    }

    public String StatDescription()
    {
        string pattern = @"
        [
            isFemale: {0}   
            maxAge: {1}
            childCount: {2}
        ]";
        return string.Format(pattern, this.isFemale, this.maxAge, this.childCount);
    }
}
