using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PCLExt.FileStorage.Folders;

namespace AppListView.Services
{
    //importa a biblioteca do SQLite (using SQLite;)
    //Importar o using PCLExt.FileStorage.Folders;
    public class DatabaseServices
    {
        //Criar uma função que retorna a conexão
        public SQLiteConnection GetConexao()
        {
            //Acessar a pasta raiz
            var folder = new LocalRootFolder();
            //Validar a existencia do arquivo, se existir utilizamos, se não existir, cria
            var file = folder.CreateFile("agawa", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            //Abrir a conexão com o banco de dados
            return new SQLiteConnection(file.Path);
        }
       
    }
}
