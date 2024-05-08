namespace Entidades
{
    public class Consola
    {
        private string? modelo;
        private bool conectividadOnline;
        private int almacenamiento;
        protected List<string> listaVideojuegos;

        private Consola()
        {
            listaVideojuegos = new List<string>();
        }

        public Consola(string modelo) : this()
        {
            this.Modelo = modelo;
            this.DeterminarConectividadOnline();
        }

        public Consola(string modelo, int almacenamiento) : this(modelo)
        {
            this.Almacenamiento = almacenamiento;
        }

        public string? Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        public int Almacenamiento
        {
            get { return this.almacenamiento; }
            set { this.almacenamiento = value; }
        }

        protected void DeterminarConectividadOnline()
        {
            if (ConectividadOnline.ObtenerConectividadOnline(this.modelo))
            {
                this.conectividadOnline = true;
            }
            else
            {
                this.conectividadOnline = false;
            }
        }
    }
}
