using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Financeiro_WEB_MVC.Models;

namespace Projeto_Financeiro_WEB_MVC.Controllers
{
    //Precisa herdar a classe controller!
    public class UsuarioController : Controller
    {
        //por default é get

        [HttpGet]
        public ActionResult Cadastrar(){
        
            return View(); //Só vai conseguir acessar a view que eu desejo se eu criar uma pasta na views com o nome da classe, e nomear  o arquivo cshtml com o mesmo nome da action
        }

        [HttpPost]
        public ActionResult Cadastrar(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel();

            //guardando os valores recebidos no formulário
            usuario.Nome = form["nome"]; //usuario.Nome vai receber o valor que a pessoa inserir no form nome
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];
            usuario.DataNascimento = DateTime.Parse(form["dataNascimento"]);
            
            using(StreamWriter sw = new StreamWriter("usuarios.csv",true)) {
                sw.WriteLine($"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento}");
            } //não precisa de sw.close() pq o using já faz isso automaticamente


            ViewBag.Mensagem = "Usuário cadastrado!";
            return View();
        }

        [HttpGet] 
        public IActionResult Login() {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel();
            usuario.Email = form["email"]; //tem que usar usuario.Email, e não simplesmente uma variável email pois abaixo
            usuario.Senha = form["senha"];

            using (StreamReader sr = new StreamReader("usuarios.csv")){
                while(!sr.EndOfStream) {
                    string[] linha = sr.ReadLine().Split(";");

                    if(linha[1] == usuario.Email && linha[2]==usuario.Senha){
                        HttpContext.Session.SetString("emailUsuario", usuario.Email); //Aceita como parâmetro um objeto
                        return RedirectToAction("Cadastrar", "Transacao");
                    }
                }
            }
            ViewBag.Mensagem = "Usuário inválido!";
            return View();
        }
    }
}