using System.ComponentModel.DataAnnotations;

namespace Catalogo.Modelos
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El correo es requerido.")]
        [EmailAddress(ErrorMessage = "Correo invalido.")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El telefono es requerido.")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres.")]
        public string? Telefono { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "La clasificacion es requerida")]
        public int ClasificacionId { get; set; }
        virtual public Clasificacion? Clasificacion { get; set; }

    }
}
