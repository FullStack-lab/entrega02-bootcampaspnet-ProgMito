﻿using SistemaComentarios.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaComentario.Controllers
{
    public class ComentarioController : Controller
    {
        private static List<Comentario> comentarios = new List<Comentario>();
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
                comentario.Id = comentarios.Count + 1;
                comentario.DataPost = DateTime.Now;
                comentarios.Add(comentario);
                return RedirectToAction("Index");
            }
            return View(comentario);
        }
    }
}