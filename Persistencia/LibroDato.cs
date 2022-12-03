using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class LibroDato: Entity<string>
    {
        private string isbn;
        private string titulo;
        private string autor;
        private string editorial;
        private string personalBAlta;
        public LibroDato(string isbn, string titulo, string autor, string editorial, string personal): base(isbn)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.personalBAlta = personal;
        }
        public string Isbn { get { return isbn; } }
        public string Titulo { get { return titulo; } set { titulo = value; } }
        public string Autor { get { return autor; } set { autor = value; } }
        public string Editorial { get { return editorial; } set { editorial = value; } }
    }
}
