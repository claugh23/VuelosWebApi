namespace VuelosWebApi.Models
{
    public class Vuelo
    {
        public int Id_Vuelo { get; set; }
        public int Compani_Id_Compani { get; set; }
        public int Intinerario_Id_Intinerario { get; set; }
        public int Capacidad { get; set; }
        public string NumeroVuelo { get; set; }
    }
}
