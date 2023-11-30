using Gestor_de_tareas.Datas;

namespace Gestor_de_tareas;


public partial class NewPage1 : ContentPage
{
    Conexion connect = new Conexion();
    
	public NewPage1()
	{
		InitializeComponent();
        connect.CrearTabla();     
	}

    public async void sig_pag_boton_Clicked(object sender, EventArgs e)
    {
        
        string contenidoaux = entrada_de_Contenido.Text;
        string nombreaux = entrada_de_Nombre_tarea.Text;

        DateTime fechaaux = Fecha_creacion.Date;

        int _dia = Fecha_creacion.Date.Day;
        int _mes = Fecha_creacion.Date.Month;
        int _anhio = Fecha_creacion.Date.Year;
        string Ddia = _dia.ToString();
        try
        {
            connect.InsertarTarea(nombreaux,contenidoaux);
            Navigation.PushAsync(new MainPage(),true);
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "ok");
        }
    }
}