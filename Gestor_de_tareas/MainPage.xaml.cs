using Gestor_de_tareas.Datas;
using Gestor_de_tareas.Resources;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace Gestor_de_tareas

{
    
    public partial class MainPage : ContentPage
    {
       
        public  MainPage()
        {
            
            Conexion conexion = new Conexion();
            conexion.CrearTabla();

            InitializeComponent();
              
        }

        private async void Agregar_tarea_boton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new paginausuario());
        }

        private async void boton_refresh_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(),false);
        }

        private async void eliminador_Clicked(object sender, EventArgs e)
        {
           Conexion conexion = new Conexion();
            if(await DisplayAlert("confirmar","¿Quieres eliminar la tarea?","si","no"))
            {
                var obj = (Tareas)(sender as MenuItem).CommandParameter;

              string nombre = obj.Nombre_Tarea;
               
                conexion.Eliminador(nombre);
                
                await Navigation.PushAsync(new MainPage(),false);
            }
        }

        private async void Detalles_Clicked(object sender, EventArgs e)
        {
           var objeto=(Tareas)(sender as MenuItem).CommandParameter;
            string fechaeaux = objeto.fechaux;
            

            await DisplayAlert("tarea Creada El:", fechaeaux,"OK");
        }
    }
}