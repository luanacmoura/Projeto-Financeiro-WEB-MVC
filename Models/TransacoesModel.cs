using System;

namespace Teste_WEB_MVC.Models
{
    public class TransacoesModel
    {
        public string Desc { get; set; }
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public DateTime DataTransacao { get; set; }
    }
}