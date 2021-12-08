using System;

namespace VuelosWebApi.Models
{
    public class Intinerario
    {
        public int Id_Intinerario { get; set; }
        public int Destino_Id_Destino { get; set; }
        public int Origen_Id_Destino { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
    }
}
