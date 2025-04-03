using Heirloom;

namespace Ping_Pong;

public class Pala(Rectangle posicioInicial, int velocitatInicial) : ObjectePantallaMou(posicioInicial, velocitatInicial) //aquests parametres els rep del pare
{ 
    //el mou el rep del objectepantallamou
    public override Rectangle Hitbox()
    {
        return Posicio;
    }
}