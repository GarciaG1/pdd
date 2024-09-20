public interface IComponent
{
    void Operation();
}

public class Leaf : IComponent
{
    public void Operation() => Console.WriteLine("Leaf operation");
}

public class Composite : IComponent
{
    private List<IComponent> children = new List<IComponent>();

    public void Add(IComponent component) => children.Add(component);
    public void Remove(IComponent component) => children.Remove(component);

    public void Operation()
    {
        Console.WriteLine("Composite operation");
        foreach (var child in children)
        {
            child.Operation();
        }
    }
}
