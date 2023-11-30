using Gestor_de_tareas.Datas;

namespace Gestor_de_tareas;

public partial class paginausuario : ContentPage
{
	public paginausuario()
	{
		InitializeComponent();
	}

    public void boton_sgte_2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewPage1());

        string apellidoaux = entry_apellido.Text;
        string nombreaux = entry_usuario.Text;

        Usuario usuarioaux= new Usuario();
        usuarioaux.Nombre_usuario = nombreaux;
        usuarioaux.Apellido_usuario= apellidoaux;
        int diaaux = fecha_nacimiento_picker.Date.Day;
        int mesaux = fecha_nacimiento_picker.Date.Month;
        int anhoaux = fecha_nacimiento_picker.Date.Year;

        Fecha f_nacimientoaux = new Fecha(diaaux, mesaux, anhoaux);
       
        usuarioaux.Fecha_nacimiento_usuario= f_nacimientoaux;
    }
}