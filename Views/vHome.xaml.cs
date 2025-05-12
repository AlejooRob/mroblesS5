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
        LimpiarCampos();
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        lblstatusMsg.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personaRepo.UpdatePersona(id, txtNombre.Text);
            lblstatusMsg.Text = App.personaRepo.statusMessage;
            LimpiarCampos();
        }
        else
        {
            lblstatusMsg.Text = "ID inválido.";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblstatusMsg.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personaRepo.DeletePersona(id);
            lblstatusMsg.Text = App.personaRepo.statusMessage;
            LimpiarCampos();
        }
        else
        {
            lblstatusMsg.Text = "ID inválido.";
        }
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblstatusMsg.Text = "";
        List<Persona> lista = App.personaRepo.GetAllPersona();
        cwListPersonas.ItemsSource = lista;
    }

    private void LimpiarCampos()
    {
        txtId.Text = "";
        txtNombre.Text = "";
    }
}