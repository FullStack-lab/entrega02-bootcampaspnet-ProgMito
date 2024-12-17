using System;
using System.Collections.Generic;

namespace SistemaComentarios.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Texto { get; set; }
        public DateTime DataPost { get; set; }
        public List<Resposta> Respostas { get; set; }


        public Comentario()
        {
            Respostas = new List<Resposta>();
        }
    }
}