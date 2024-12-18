using SistemaComentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SistemaComentario.Controllers
{
    public class ComentarioController : Controller
    {
        public static List<Comentario> comentarios = new List<Comentario>();
        public static List<Resposta> respostas = new List<Resposta>();
        public ActionResult Index()
        {
            return View(comentarios);
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.Id = comentarios.Count > 0 ? comentarios.Max(c => c.Id) + 1 : 1;
                comentario.DataPost = DateTime.Now;
                comentarios.Add(comentario);
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        public ActionResult Detalhes(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }



        [HttpGet]
        public ActionResult Editar(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
                return HttpNotFound();
            return View(comentario);
        }

        [HttpPost]
        public ActionResult Editar(Comentario comentario)
        {
            var original = comentarios.FirstOrDefault(c => c.Id == comentario.Id);
            if (original != null && ModelState.IsValid)
            {
                original.Texto = comentario.Texto;
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        public ActionResult Excluir(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario != null)
            {
                comentarios.Remove(comentario);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AdicionarResposta(int comentarioId)
        {
            var resposta = new Resposta { ComentarioId = comentarioId };
            return View(resposta);
        }

        [HttpPost]
        public ActionResult AdicionarResposta(Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                var comentario = comentarios.FirstOrDefault(c => c.Id == resposta.ComentarioId);
                if (comentario != null)
                {
                    resposta.Id = comentario.Respostas.Count > 0 ? comentario.Respostas.Max(r => r.Id) + 1 : 1;
                    resposta.DataPost = DateTime.Now;
                    comentario.Respostas.Add(resposta);
                }
                return RedirectToAction("Detalhes", new { id = resposta.ComentarioId });
            }

            return View(resposta);
        }

    }
}