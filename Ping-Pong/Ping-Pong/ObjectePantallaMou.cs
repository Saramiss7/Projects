using Heirloom;
namespace Ping_Pong;

public abstract class ObjectePantallaMou:ObjectePantalla
{
    protected int Velocitat;

    public ObjectePantallaMou(Rectangle posicio, int velocitat) :
        base(posicio) //simplifiquem el metode mou que està a tots els objectes
    {
        Velocitat = velocitat;
    }
    
    public bool Mou(Vector direccio, Rectangle midaPantalla)
    {
        if (direccio.X ==0 && direccio.Y ==0) return false; //si la direccio es 0, no es mou per estalviar cpu
        
        var novaPosicio = Posicio;
        novaPosicio.Offset(direccio*Velocitat); //calculem on va, offset serveix per evitar posar .y i .x

        if (midaPantalla.Contains(novaPosicio)) //fem que es mogui la pala si no es surt de la pantalla
        {
            Posicio = novaPosicio;
            return true; //si s'ha mogut, retorna true
        }
        return false;
    }

    public abstract Rectangle Hitbox();

    public override Vector Centre()
    {
        return Posicio.Center;
    }
}