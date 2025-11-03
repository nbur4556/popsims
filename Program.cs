Entity entity = new Entity();
Console.WriteLine(entity.StatDescription());

public class Entity
{
    private bool isFemale;
    private int maxAge;

    public Entity()
    {
        var rand = new Random();
        this.isFemale = rand.Next(2) == 0;
        this.maxAge = rand.Next(100);
    }

    public String StatDescription()
    {
        string pattern = @"
        [
            isFemale: {0}   
            maxAge: {1}
        ]";
        return string.Format(pattern, this.isFemale, this.maxAge);
    }
}
