using System.ComponentModel.DataAnnotations;

namespace TiendaApi.Entity
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string postal { get; set; }

        public string correo { get; set; }

        public string contraseña { get; set; }

        public int RolId { get; set; }

        public Rol rol { get; set; }

    }
}
