namespace EmpleadosAPI.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public DateOnly fechaNacimiento { get; set; }
        public string genero { get; set; }
    }
}
