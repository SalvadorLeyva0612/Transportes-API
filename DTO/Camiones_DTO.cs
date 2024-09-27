using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Camiones_DTO
    {
        
        public int ID_camiones { get; set; }
        
        public string matricula { get; set; }

        public int capacidad { get; set; }
        
        public string tipo_camion { get; set; }
        public string urlfoto { get; set; }
        
        public string marca { get; set; }
        public string modelo { get; set; }

        public double kilometraje { get; set; }

        public bool disponibilidad { get; set; }
    }
}
