public interface IImplementor
{
    void Operation();
}

public class ConcreteImplementorA : IImplementor
{
    public void Operation() => Console.WriteLine("Operation in ConcreteImplementorA");
}

public abstract class Abstraction
{
    protected IImplementor implementor;

    public Abstraction(IImplementor implementor)
    {
        this.implementor = implementor;
    }

    public abstract void Operation();
}

public class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(IImplementor implementor) : base(implementor) { }

    public override void Operation()
    {
        implementor.Operation();
    }
}
