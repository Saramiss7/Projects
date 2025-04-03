using Heirloom;
namespace Ping_Pong;

public abstract class ObjectePantalla
{
    public Rectangle Posicio { get; protected set; } //els fills poden modificar la posicio

    protected ObjectePantalla(Rectangle posicio)
    {
        Posicio = posicio;
    }
    public abstract Vector Centre();
}