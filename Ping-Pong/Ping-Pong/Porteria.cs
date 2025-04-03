using Heirloom;
namespace Ping_Pong;

//porteria te un constructor que necessita un rectangle, el rectangle posicio prove del pare
public class Porteria(Rectangle posicioInicial) : ObjectePantalla(posicioInicial)
{
    public override Vector Centre()
    {
        return Posicio.Center;
    }
}