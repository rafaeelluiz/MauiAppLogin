namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<DadosUsu�rio> lista_usuarios = new List<DadosUsu�rio>
			{
				new DadosUsu�rio()
				{
					Usuario="jos�",
					Senha = "123"
				},
				new DadosUsu�rio()
				{
					Usuario = "maria",
					Senha = "321"
				},

			};

			DadosUsu�rio dados_digitados = new DadosUsu�rio()
			{
				Usuario = txt_usu�rio.Text,
				Senha = txt_senha.Text
			};


			//	LINQ
			if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha))  )

			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();
			}else
			{
				throw new Exception("Usu�rio ou senha incorretos.");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("OPS", ex.Message, "FECHAR");
		}



    }
}