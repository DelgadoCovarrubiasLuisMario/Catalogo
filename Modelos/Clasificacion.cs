using System.ComponentModel.DataAnnotations;

namespace Catalogo.Modelos
{
    public class Clasificacion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100, ErrorMessage =  "Maximo 100 caracteres")]
        public string? Name { get; set; }
        virtual public ICollection<Persona>? Personas { get; set; }

    }
}
