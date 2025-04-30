using mroblesS5.Models;

namespace mroblesS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblstatusMsg.Text = "";
        App.personaRepo.AddnewPerson(txtNombre.Text);
        lblstatusMsg.Text = App.personaRepo.statusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblstatusMsg.Text = "";
        List<Persona> lista = App.personaRepo.GetAllPersona();
        cwListPersonas.ItemsSource = lista;
    }
}