using AppListView.Models;

namespace AppListView;

public partial class pgVisPessoa : ContentPage
{
    //adicionar parametro Pessoa no construtor da tela
    public pgVisPessoa(Pessoa pessoa)
    {
        //nesse momento ja temos o cadastro dentro da tela. Precisa só exibir agora
        InitializeComponent();
        ExibirDados(pessoa);
    }

    private void ExibirDados(Pessoa pessoa)
    {
        //Mapeamento do objeto com os campos em tela
        lblId.Text = pessoa.Id.ToString();
        lblNome.Text = pessoa.Nome.ToString();
        lblIdade.Text = pessoa.Idade.ToString();
    }
    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}