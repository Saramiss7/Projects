using Heirloom;
namespace Ping_Pong;


public class Marcador: ObjectePantalla
{
    private readonly int[] _punts = new int[2];

    public Marcador(Rectangle posicio) : base(posicio)
    {
        //en c# no fa falta, java si
        _punts[0] = 0;
        _punts[1] = 0;
    }
    
    public void Gol(int jugadorQueHaMArcat)
    {
        _punts[jugadorQueHaMArcat]++;
    }

    public override Vector Centre()
    {
        return Posicio.Center;
    }

    public string Resultat()
    {
        return $"{_punts[0]}  {_punts[1]}";
    }
}