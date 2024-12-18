using SistemaComentario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaComentario.Controllers
{
    public class RespostaController : Controller
    {
        public static List<Comentario> comentarios = ComentarioController.comentarios;

        [HttpGet]
        public ActionResult Criar(int comentarioId)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == comentarioId);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            var resposta = new Resposta { ComentarioId = comentarioId };
            return View(resposta);
        }

        [HttpPost]
        public ActionResult Criar(Resposta resposta)
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
                return RedirectToAction("Detalhes", "Comentario", new { id = resposta.ComentarioId });
            }
            return View(resposta);
        }

        [HttpGet]
        public ActionResult Editar(int id, int comentarioId)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == comentarioId);
            if (comentario == null)
                return HttpNotFound();

            var resposta = comentario.Respostas.FirstOrDefault(r => r.Id == id);
            if (resposta == null)
                return HttpNotFound();

            return View(resposta);
        }

        [HttpPost]
        public ActionResult Editar(Resposta resposta)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == resposta.ComentarioId);
            if (comentario != null)
            {
                var respostaExistente = comentario.Respostas.FirstOrDefault(r => r.Id == resposta.Id);
                if (respostaExistente != null && ModelState.IsValid)
                {
                    respostaExistente.Texto = resposta.Texto;
                    return RedirectToAction("Detalhes", "Comentario", new { id = resposta.ComentarioId });
                }
            }
            return View(resposta);
        }

        public ActionResult Excluir(int id, int comentarioId)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == comentarioId);
            if (comentario != null)
            {
                var resposta = comentario.Respostas.FirstOrDefault(r => r.Id == id);
                if (resposta != null)
                {
                    comentario.Respostas.Remove(resposta);
                }
            }
            return RedirectToAction("Detalhes", "Comentario", new { id = comentarioId });
        }
    }
}
