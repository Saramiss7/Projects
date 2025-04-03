using Heirloom;
namespace Ping_Pong;

public class Pilota(Rectangle posicio, Vector direccio, int velocitat) : ObjectePantallaMou(posicio, velocitat) //aquests parametres els rep del pare
{
    private Rectangle Centre = posicio;
    private Vector _direcio = direccio;
    private readonly int _velocitatInicial = velocitat;

    public void Mou(Rectangle rectanglePermes) //el rectangle on es poden moure les pales
    {
        if (!base.Mou(_direcio, rectanglePermes))
        {
            var novaPosicio = Posicio;
            novaPosicio.Offset(_direcio * Velocitat); //si es mou tant en x com en y és offset
            
            if (rectanglePermes.Top > novaPosicio.Top || rectanglePermes.Bottom < novaPosicio.Bottom)
            {
                _direcio.Y *= -1;
            }
            else
            {
                //Això s'haura de treure
                _direcio.X *= -1;
            }
        }
    }

    public override Rectangle Hitbox()
    {
        return new Rectangle(Posicio.X+3, Posicio.Y+3, Posicio.Width-3, Posicio.Height-3);
    }

    public void Rebota(Rectangle palaPosicio)
    {
        Velocitat = _velocitatInicial;
        _direcio.X *= -1;
        
        var desplasament = ((Posicio.Y + Posicio.Height) - palaPosicio.Y)/(palaPosicio.Height - Posicio.Height);
        
        //d'angles a radiants
        var angle = 0.25f * Calc.Pi * (2 * desplasament - 1);
        _direcio.Y = Calc.Sin(angle);
    }

    public void TornaCentre(Vector novaDireccio)
    {
        Posicio = Centre;
        _direcio = novaDireccio;
        Velocitat = _velocitatInicial/2;
    }
}