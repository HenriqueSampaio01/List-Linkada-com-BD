using SQLite;
using AppListView.Models;
using AppListView.Services;


namespace AppListView.Controllers
{
    public class PessoaController
    {
        private DatabaseServices DatabaseServices;

        private SQLiteConnection connection;

        //Cria o método construtor
        public PessoaController()
        {
            //Instancia a DatabaseService
            DatabaseServices = new DatabaseServices();

            //Recupera a conexão do BD
            connection = DatabaseServices.GetConexao();
            //Mapear o objeto Pessoa para criação/atualização da tabela no BD
            connection.CreateTable<Pessoa>();
        }

        public bool Insert(Pessoa value)
        {
            //O Insert retorna o numero de linhas afetadas
            return connection.Insert(value) > 0;
        }

        public bool Update(Pessoa value)
        {
            //Seguir a mesma ideia do Insert
            return connection.Update(value) > 0;
        }

        public bool Delete(Pessoa value)
        {
            
            return connection.Delete(value) > 0;
        }

        public List<Pessoa> GetAll()
        {
            //Retorna todos os registros da tabela
            return connection.Table<Pessoa>().ToList();
        }

        public Pessoa GetById(int value)
        {
            //Utilizar o recurso Find
            //para encontrar o registro pelo ID
            return connection.Find<Pessoa>(value);
        }

        public List<Pessoa> GetByNome(string value)
        {
            //Utilizar o recurso Where
            //para encontrar o registro pelo nome
            return connection.Table<Pessoa>().Where(x => x.Nome.Contains(value)).ToList();
        }
    }
}
