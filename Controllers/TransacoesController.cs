using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_WEB_MVC.Models;

namespace Teste_WEB_MVC.Controllers
{
    public class TransacoesController : Controller
    {
        [HttpGet]
        public ActionResult Cadastro() {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(IFormCollection form){
            TransacoesModel transacao = new TransacoesModel();

            transacao.Desc = form["descricao"];
            transacao.Valor = double.Parse(form["valor"]);

            if (form["tipo"]=="Receita"){
                transacao.Tipo = "Receita";
            } 
            else {
                transacao.Tipo="Despesa";
            }

            transacao.DataTransacao= DateTime.Parse(form["datatransacao"]);
            
            ViewBag.Mensagem="Transação cadastrada!";
        
            return View();
        }
    }
}