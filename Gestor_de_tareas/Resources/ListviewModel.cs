using Gestor_de_tareas.Datas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestor_de_tareas;
using System.Windows.Input;

namespace Gestor_de_tareas.Resources
{
    public class ListViewModel : INotifyPropertyChanged
    {
        Conexion conn = new Conexion();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Tareas> _tareas;
        
        public List<Tareas> Tareas
        {
            get
            {
                return _tareas;
            }
            set
            {
                _tareas = value;
                OnPropertyChanged(nameof(Tareas));

            }
        }
        public void AgrgarTareas(Tareas tareaagregar)
        {
            _tareas.Add(tareaagregar);

            OnPropertyChanged(nameof(Tareas));
        }
        public ListViewModel()
        {
            Tareas = conn.Verdatos();
  
        }
    }
}