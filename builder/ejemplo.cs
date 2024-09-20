using System;

// Producto final: un Pedido (construido por el builder)
public class Pedido
{
    public string Hamburguesa { get; set; }
    public string Bebida { get; set; }
    public bool ConQueso { get; set; }
    public bool ConLechuga { get; set; }
    public bool ConTomate { get; set; }

    public override string ToString()
    {
        return "Hamburguesa: " + Hamburguesa + ", Queso: " + ConQueso + ", Lechuga: " + ConLechuga +
               ", Tomate: " + ConTomate + ", Bebida: " + Bebida;
    }
}

// Interfaz Builder para construir pedidos
public interface IPedidoBuilder
{
    void AgregarHamburguesa(string tipo);
    void AgregarBebida(string bebida);
    void ConQueso();
    void ConLechuga();
    void ConTomate();
    Pedido ObtenerPedido();
}

// Implementación del Builder para construir un pedido paso a paso
public class PedidoBuilder : IPedidoBuilder
{
    private Pedido _pedido = new Pedido();

    public void AgregarHamburguesa(string tipo)
    {
        _pedido.Hamburguesa = tipo;
    }

    public void AgregarBebida(string bebida)
    {
        _pedido.Bebida = bebida;
    }

    public void ConQueso()
    {
        _pedido.ConQueso = true;
    }

    public void ConLechuga()
    {
        _pedido.ConLechuga = true;
    }

    public void ConTomate()
    {
        _pedido.ConTomate = true;
    }

    public Pedido ObtenerPedido()
    {
        return _pedido;
    }
}

// Clase principal que contiene el método Main()
public class Program
{
    public static void Main(string[] args)
    {
        // Crear el director
        Director director = new Director();

        // Crear un nuevo builder de pedidos
        PedidoBuilder builder = new PedidoBuilder();

        // Construir un pedido completo
        director.ConstruirPedidoCompleto(builder);
        Pedido pedidoCompleto = builder.ObtenerPedido();
        Console.WriteLine("Pedido Completo: " + pedidoCompleto);

        // Construir un pedido simple
        PedidoBuilder builderSimple = new PedidoBuilder();
        director.ConstruirPedidoSimple(builderSimple);
        Pedido pedidoSimple = builderSimple.ObtenerPedido();
        Console.WriteLine("Pedido Simple: " + pedidoSimple);
    }
}

// Director: controla el proceso de construcción
public class Director
{
    public void ConstruirPedidoCompleto(IPedidoBuilder builder)
    {
        builder.AgregarHamburguesa("Hamburguesa de Pollo");
        builder.ConQueso();
        builder.ConLechuga();
        builder.ConTomate();
        builder.AgregarBebida("Coca Cola");
    }

    public void ConstruirPedidoSimple(IPedidoBuilder builder)
    {
        builder.AgregarHamburguesa("Hamburguesa Simple");
        builder.AgregarBebida("Agua");
    }
}
