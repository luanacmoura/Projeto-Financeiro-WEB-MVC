using System;

namespace Projeto_Financeiro_WEB_MVC.Models
{
    public class TransacaoModel
    {
        public int Id {get; set;}
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
    }
}