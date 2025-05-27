using System.Collections.ObjectModel;
using AppListView.Controllers;
using AppListView.Models;
using AppListView.Views;


namespace AppListView
{
    public partial class MainPage : ContentPage
    {
        //Importar as camadas:
        //using AppListView.Controllers;
        //using AppListView.Models;
        //using AppListView.Views;

        //Cria a instancia da classe pessoaController

        private PessoaController pessoaController;
        public MainPage()
        {
            InitializeComponent();
            //Instanciar a classe e atribuir a variavel
            pessoaController = new PessoaController();

            AtualizarListView();
        }

        //Método para atualizar a ListView
        private void AtualizarListView()
        {
            lsvLista.ItemsSource = pessoaController.GetAll();
        }


        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            //Precisamos do modo Async, para aguardar a finalização do cadastro
            await Application.Current.MainPage.Navigation.PushAsync(new pgCadPessoa());

            //Após finalizar o cadastro, atualizamos a tela
            AtualizarListView();
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            AtualizarListView();
        }

        private void tapVisualizar_Tapped(object sender, TappedEventArgs e)
        {
            //Reconhecer se o gesto é do tipo Tapped.
            TappedEventArgs tapped = (TappedEventArgs)e;

            //Precisamos validar se o registro selecionado é realmente do tipo pessoa. se for extrai objeto ListView
            if (tapped.Parameter is Pessoa registro)
            {
                //Chamar a tela de visualizar, onde vai passar o registro extraido via parametro
                Application.Current.MainPage.Navigation.PushAsync(new pgVisPessoa(registro));
            }
        }

        private async void tapExcluir_Tapped(object sender, TappedEventArgs e)
        {
            //Seguir a mesma ideia da rotina de visualizar, onde precisa realizar a identificação do gesto tapped
            //E extrai o objeto do registro selecionado
            TappedEventArgs tapped = (TappedEventArgs)e;

            if (tapped.Parameter is Pessoa registro)
            {
                //iremos usar displayalert para confirmar a exclusão
                //por ele ficar aberto até a tomada de decisão, é preciso chama-lo de maneira async
                bool decisao = await DisplayAlert("Confirmação de exclusão", "Deseja realmente exlcuiro o registro?",
                                            "sim", "não");

                if (decisao)
                {
                    pessoaController.Delete(registro);
                    AtualizarListView();
                }
            }
        }
    }
}
