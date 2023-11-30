using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_tareas.Datas
{
    public  class Tareas
    {
        public string Nombre_Tarea {  get; set; }
        public Fecha FechaCreacion { get; set; }
        public string Contenido_Tarea { get; set; }
        public Usuario Usuario_creador { get; set; }
        public string fechaux {  get; set; }
        public ImageSource Imagen {  get; set; }
    }
}
