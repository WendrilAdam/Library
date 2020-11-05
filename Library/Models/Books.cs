using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Books
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public double Valor { get; set; }
    }
}
