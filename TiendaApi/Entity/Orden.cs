namespace TiendaApi.Entity
{
    public class Orden
    {
        public int Id { get; set; }

        public DateTime fecha { get; set; }

        public Usuario usuario {get; set;}
        public int UsuarioId {get; set;}

        public bool entregado {get; set;}

        public double granTotal {get; set;}
    }
}
