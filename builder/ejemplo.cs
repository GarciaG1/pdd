public class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
}

public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    Product GetResult();
}

public class ConcreteBuilder : IBuilder
{
    private Product product = new Product();

    public void BuildPartA() => product.PartA = "PartA";
    public void BuildPartB() => product.PartB = "PartB";
    public Product GetResult() => product;
}

public class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}
