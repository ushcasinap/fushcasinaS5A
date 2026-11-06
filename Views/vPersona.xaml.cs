namespace fushcasinaS5A.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnMostar_Clicked(object sender, EventArgs e)
    {
        List<Models.Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        App._personRepo.AddNewPerson(txtName.Text);
        lblStatusMessage.Text = App._personRepo.StatusMessage;
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        // Persona seleccionada en la lista
        Models.Persona? persona = listaPersonas.SelectedItem as Models.Persona;

        if (persona == null)
        {
            lblStatusMessage.Text = "Seleccione una persona de la lista";
            return;
        }

        // Confirmar antes de eliminar
        bool respuesta = await DisplayAlertAsync("Eliminar",
                                                 "¿Desea eliminar a " + persona.Name + "?",
                                                 "Sí", "No");
        if (!respuesta)
            return;

        // Elimina solo la persona seleccionada (por su Id)
        App._personRepo.DeletePerson(persona.Id);
        lblStatusMessage.Text = App._personRepo.StatusMessage;

        // Actualizar la lista
        listaPersonas.SelectedItem = null;
        listaPersonas.ItemsSource = App._personRepo.GetAllPerson();
    }
}