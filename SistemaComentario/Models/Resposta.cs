using System;

namespace SistemaComentarios.Models
{
    public class Resposta
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Texto { get; set; }
        public DateTime DataPost { get; set; }
        public int ComentarioId { get; set; }
        public Comentario Comentario { get; set; }
    }

}