using Heirloom;
using Heirloom.Desktop;
namespace Ping_Pong;

public class Camp
{
    private Window _finestra;
    private Pala _pala = null!;
    private List<Pala> _pales = new();
    private readonly Porteria[] _porteria = new Porteria[2];
    private List<Corner> _corner = new();
    private Dictionary<string, Image> _imatges = new();
    private Pilota _pilota = null!; //continuar
    private Rectangle rectangleOnEsPotMourePala = new Rectangle(15,25,995, 725);
    private Marcador _marcador;
    public Camp(Window finestra)
    {
        _finestra = finestra;
    }
    
    public void Carrega()
    {
        //  Carrega Imatges
        //_imatges["pilota"] = new Image("path");
        
        //Crear objectes
        //Pales
        var posicioPala1 = new Rectangle(35, 100, 20, 100);
        _pales.Add(new Pala(posicioPala1,5));
        var posicioPala2 = new Rectangle(_finestra.Width -50, 100, 20, 100);
        _pales.Add(new Pala(posicioPala2,5));
        
        //Porteries
        var posicioPorteria1 = new Rectangle(15, 25, 5, 725);
        _porteria[0]=(new Porteria(posicioPorteria1));
        var posicioPorteria2 = new Rectangle(_finestra.Width - 17, 25, 5, 725);
        _porteria[1]=(new Porteria(posicioPorteria2));
        
        //Eix Y Walls(Corner)
        var posicioCorner1 = new Rectangle(15, 25, 995, 7);
        _corner.Add(new Corner(posicioCorner1));
        var posicioCorner2 = new Rectangle(15, _finestra.Height - 25, 995, 7);
        _corner.Add(new Corner(posicioCorner2));
        
        //Pilota
        var posicioPilota = new Rectangle(_finestra.Width/2-5,_finestra.Height/2-5,10,10);
        _pilota = new Pilota(posicioPilota, new Vector(1,1),5); //la pilota va cap a la dreta al inici
        
        //Marcador
        _marcador = new Marcador(new Rectangle(rectangleOnEsPotMourePala.Width*0.5f,10, 10,50));
    }
    
    public void MouObjectes(GraphicsContext gfx)
    {
        Moure();
        Pinta(gfx);
        Interacio();
    }

    public void Interacio()
    {
        //marcar punts
        for (var index = 0; index < _porteria.Length; index++)
        {
            var porteria = _porteria[index];
            if (_pilota.Hitbox().Overlaps(porteria.Posicio))
            {
                //gol
                _marcador.Gol((index + 1) % 2);

                var novaDireccio = new Vector(1, 0);
                if (index == 1)
                {
                    novaDireccio = new Vector(-1, 0);
                }
                _pilota.TornaCentre(novaDireccio);
                return;
            }
        }

        //rebotar
        foreach (var pala in _pales)
        {
            if (_pilota.Hitbox().Overlaps(pala.Posicio))
            {
                _pilota.Rebota(pala.Posicio);
                return;
            }
        }
    }

    public void Moure()
    {
        //Moure pales
        var movimentPala = new Vector[2]; //array de vectors
        if (Input.CheckKey(Key.Up, ButtonState.Down))
        {
            movimentPala[0] = new Vector(0, -1);
        }
        if (Input.CheckKey(Key.Down, ButtonState.Down))
        {
            movimentPala[0] = new Vector(0, +1);
        }
        if (Input.CheckKey(Key.W, ButtonState.Down))
        {
            movimentPala[1] = new Vector(0,-1);
        }
        if (Input.CheckKey(Key.S, ButtonState.Down))
        {
            movimentPala[1] = new Vector(0,+1);
        }

        var i = 0;
        
        foreach (var pala in _pales)
        {
            pala.Mou(movimentPala[i], rectangleOnEsPotMourePala);
            i++;
        }
        
        //moure pilota
        _pilota.Mou(rectangleOnEsPotMourePala);
    }

    public void Pinta(GraphicsContext gfx)
    {
        
        gfx.Clear(Color.Pink);
        foreach (var pala in _pales)
        {
            gfx.DrawRect(pala.Posicio);
        }
        
        foreach (var porteria in _porteria)
        {
            gfx.DrawRect(porteria.Posicio);
        }

        foreach (var corner in _corner)
        {
            gfx.DrawRect(corner.Posicio);
        }
        
        gfx.DrawRect(_pilota.Posicio);
        
        gfx.DrawText(_marcador.Resultat(), _marcador.Posicio.Center, Font.Default, 80, TextAlign.Center | TextAlign.Top);

        gfx.DrawLine(new Vector(rectangleOnEsPotMourePala.Width / 2, rectangleOnEsPotMourePala.Y), new Vector(rectangleOnEsPotMourePala.Width / 2, 745));
    }
}