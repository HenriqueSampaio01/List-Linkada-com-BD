using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppListView.Models
{
    //importa a biblioteca do SQLite (using SQLite;)
    //Sempre deixar public as classes
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string dataNascimento { get; set; }
        public string Profissao { get; set; }
    }
}
