﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    public class GestorBD
    {
        public GestorBD()
        {

        }

        public bool CrearLibro(Libro l)
        {
            return BD.CREATE<string, LibroDato>(l);
        }
        
        public Libro BuscarLibro(string id)
        {
            return BD.READ<string, LibroDato>(id);
        }

        public bool ActualizarLibro()
        {

        }

        public bool EliminarLibro(string id)
        {
            return BD.DELETE<string, LibroDato>(id);
        }

        public bool CrearEjemplar(Ejemplar e)
        {
            return BD.CREATE<string, EjemplarDato>(e);
        }
        public Ejemplar BuscarEjemplar(string id)
        {
            return BD.READ<string, EjemplarDato>(id);
        }
        public bool ActualizarEjemplar()
        {

        }
        public bool EliminarEjemplar(string id)
        {
            return BD.DELETE<string, EjemplarDato>(id);
        }
        public bool CrearPrestamo(Prestamo p)
        {
            return BD.CREATE<string, PrestamoDato>(p);
        }
        public Prestamo BuscarPrestamo(string id)
        {
            return BD.READ<string, PrestamoDato>(id);
        }
        public bool ActualizarPrestamo()
        {

        }
        public bool EliminarPrestamo(string id)
        {
            return BD.DELETE<string, PrestamoDato>(id);
        }
        public bool CrearPersonal(PersonalBiblioteca p)
        {
            return BD.CREATE<string, PersonalBibliotecaDato>(p);
        }
        public PersonalBiblioteca BuscarPersonal(string id)
        {
            return BD.READ<string, PersonalBibliotecaDato>(id);
        }
        public bool ActualizarPersonal()
        {

        }
        public bool EliminarPersonal(string id)
        {
            return BD.DELETE<string, PersonalBibliotecaDato>(id);
        }
        public bool CrearUsuario(Usuario u)
        {
            return BD.CREATE<string, UsuarioDato>(u);
        }
        public Usuario BuscarUsuario(string id)
        {
            return BD.READ<string, UsuarioDato>(id);
        }
        public bool ActualizarUsuario()
        {

        }
        public bool EliminarUsuario(string id)
        {
            return BD.DELETE<string, UsuarioDato>(id);
        }

    }
}
