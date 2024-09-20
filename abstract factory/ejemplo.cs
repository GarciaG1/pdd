public interface IProductA
{
    string FunctionA();
}

public interface IProductB
{
    string FunctionB();
}

public class ProductA1 : IProductA
{
    public string FunctionA() => "ProductA1";
}

public class ProductB1 : IProductB
{
    public string FunctionB() => "ProductB1";
}

public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public class ConcreteFactory1 : IAbstractFactory
{
    public IProductA CreateProductA() => new ProductA1();
    public IProductB CreateProductB() => new ProductB1();
}
