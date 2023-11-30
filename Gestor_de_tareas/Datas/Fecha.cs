using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_tareas.Datas
{
    public  class Fecha
    {   public int Dia { get; set; }
        public int Mes {  get; set; }
        public int Anhio { get; set; }

        public string AuxDia { get; set; }

        public Fecha()
        {

        }

        public Fecha(int DDia,int Mmes, int Aanhio) 
        {
            this.Dia = DDia;
            this.Mes = Mmes;
            this.Anhio = Aanhio;      
        }
    }

}
