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
			List<DadosUsuário> lista_usuarios = new List<DadosUsuário>
			{
				new DadosUsuário()
				{
					Usuario="josé",
					Senha = "123"
				},
				new DadosUsuário()
				{
					Usuario = "maria",
					Senha = "321"
				},

			};

			DadosUsuário dados_digitados = new DadosUsuário()
			{
				Usuario = txt_usuário.Text,
				Senha = txt_senha.Text
			};


			//	LINQ
			if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha))  )

			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();
			}else
			{
				throw new Exception("Usuário ou senha incorretos.");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("OPS", ex.Message, "FECHAR");
		}



    }
}