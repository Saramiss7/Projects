using Heirloom;
namespace Ping_Pong;

public class Corner: ObjectePantalla
{
    public Rectangle Posicio { get; }

    public Corner(Rectangle posicio):base(posicio)
    {
        Posicio = posicio;
    }
    
    public override Vector Centre()
    {
        return Posicio.Center;
    }
}