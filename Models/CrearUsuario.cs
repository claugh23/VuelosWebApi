namespace VuelosWebApi.Models
{
    public class CrearUsuario
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string ConfPassword { get; set; }
        public string TipoUsuario_IdtiposUsuario { get; set; }

    }
}
