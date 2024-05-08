namespace Entidades
{
    public class Consola
    {
        private string? modelo;
        private bool conectividadOnline;
        private double precio;
        protected List<string> listaVideojuegos;

        public Consola()
        {
            listaVideojuegos = new List<string>();
        }
    }
}
