using AppListView.Models;
using AppListView.Controllers;
using System.Threading.Tasks;

namespace AppListView.Views;

public partial class pgCadPessoa : ContentPage
{
    //using AppListView.Models;
    //using AppListView.Controllers;
    private PessoaController pessoaController;
    public pgCadPessoa()
	{
		InitializeComponent();

        pessoaController = new PessoaController();
	}

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        string nome = txtNome.Text;
        string idade = txtIdade.Text;

        //validar os registros
        if(string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(idade))
        {
            //se estiver vazio em algum, ja aborta
            DisplayAlert("Atenção", "Preencha os campos corretamente", "OK");

            //Aborta a rotina
            return;
        }
        Pessoa pessoa = new Pessoa();
        pessoa.Nome = nome;
        pessoa.Idade = idade;

        //Realizar a inserção no BD
        if (pessoaController.Insert(pessoa))
        {
            DisplayAlert("Informação", "Registro salvo com sucesso", "OK");
            txtNome.Text = "";
            txtIdade.Text = "";
        }
        else
        {
            DisplayAlert("Erro", "Falha ao salvar o registro no banco de dados", "OK");
        }
    }
}