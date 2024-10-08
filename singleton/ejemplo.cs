public class Singleton
{
    private static Singleton instance = null;
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton is working!");
    }
}