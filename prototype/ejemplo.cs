public abstract class Prototype
{
    public abstract Prototype Clone();
}

public class ConcretePrototype : Prototype
{
    public string Name { get; set; }

    public ConcretePrototype(string name)
    {
        Name = name;
    }

    public override Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}
