4. Builder
El patrón Builder permite construir un objeto complejo paso a paso.

El patrón Builder se aplica en situaciones donde la creación de un objeto es compleja y tiene múltiples etapas o configuraciones. En este ejemplo, se está utilizando el patrón Builder para crear un pedido de comida de forma flexible, permitiendo añadir diferentes ingredientes y una bebida paso a paso.

Contexto del problema
Imagina que tienes una cadena de comida rápida donde los clientes pueden personalizar sus hamburguesas con diferentes ingredientes y bebidas. El proceso de crear un pedido puede ser complejo debido a las diferentes combinaciones de opciones (con queso, sin queso, con lechuga, etc.). En lugar de tener un constructor con muchos parámetros o una lógica de configuración complicada en una sola función, el patrón Builder divide el proceso en pasos más manejables y personalizados.


Producto final:
El objeto que queremos construir es el Pedido. Este contiene información sobre qué tipo de hamburguesa, bebida y otros detalles (queso, lechuga, tomate) forman parte del pedido.

Codigo funcionando en : https://dotnetfiddle.net/8RogLZ

public class Pedido
{
    public string Hamburguesa { get; set; }
    public string Bebida { get; set; }
    public bool ConQueso { get; set; }
    public bool ConLechuga { get; set; }
    public bool ConTomate { get; set; }
}
Interfaz Builder (IPedidoBuilder):
Esta interfaz define los métodos necesarios para construir un pedido paso a paso, pero no implementa la creación en sí misma, solo describe cómo debe ser.


public interface IPedidoBuilder
{
    void AgregarHamburguesa(string tipo);
    void AgregarBebida(string bebida);
    void ConQueso();
    void ConLechuga();
    void ConTomate();
    Pedido ObtenerPedido();
}
Implementación del Builder (PedidoBuilder):
Esta clase implementa los métodos definidos en la interfaz IPedidoBuilder para construir el objeto Pedido. Se encarga de cada paso: agregando la hamburguesa, la bebida y los ingredientes opcionales (queso, lechuga, tomate). Cada método modifica el estado del pedido.


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
El Director (Director):
El Director orquesta el proceso de construcción. En este caso, tenemos dos métodos en el Director para construir diferentes tipos de pedidos: uno completo y uno simple. El Director toma el PedidoBuilder y decide qué métodos del builder llamar para crear el objeto Pedido.


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
El Main() donde se ensamblan los pedidos:
Aquí es donde se usa el Builder. Se le pasa el builder al Director, y este se encarga de "construir" el pedido paso a paso, llamando a los métodos adecuados para añadir cada parte del pedido. Al final, el builder retorna el objeto Pedido completamente configurado.


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
Beneficios del patrón Builder en este escenario:
Flexibilidad:
Se pueden crear diferentes tipos de pedidos (completos o simples) sin tener que modificar la estructura interna de la clase Pedido. Esto permite añadir o eliminar ingredientes fácilmente sin alterar la lógica de construcción.

Simplifica la creación de objetos complejos:
En lugar de tener un constructor gigante que acepte muchos parámetros opcionales, se puede ir agregando cada parte del pedido paso a paso.

Separación de responsabilidades:
El Director decide cómo construir el pedido (qué pasos seguir), mientras que el Builder se encarga de los detalles de cómo agregar esos elementos al pedido.

Reutilización:
La implementación del Builder puede ser reutilizada en diferentes contextos para crear diversos tipos de pedidos, simplemente variando el proceso que sigue el Director.