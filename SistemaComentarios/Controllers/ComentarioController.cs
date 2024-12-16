using SistemaComentarios.Models;
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
    }
}