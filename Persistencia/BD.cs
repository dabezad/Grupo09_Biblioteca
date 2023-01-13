using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    internal class BD
    {
        private static Tabla<string, LibroDato> tLibro = new Tabla<string, LibroDato>();
        private static Tabla<string, EjemplarDato> tEjemplar = new Tabla<string, EjemplarDato>();
        private static Tabla<string, UsuarioDato> tUsuario = new Tabla<string, UsuarioDato>();
        private static Tabla<string, PrestamoDato> tPrestamo = new Tabla<string, PrestamoDato>();
        private static Tabla<string, PersonalBibliotecaDato> tPersonalBiblioteca = new Tabla<string, PersonalBibliotecaDato>();
        private static Tabla<ClaveEEP, EjemplarEnPrestamoDato> tEjemplarEnPrestamo = new Tabla<ClaveEEP, EjemplarEnPrestamoDato>();

        private BD()
        {

        }

        public static Tabla<string, LibroDato> TLibro
        {
            get { return tLibro; }
        }

        public static Tabla<string, EjemplarDato> TEjemplar
        {
            get { return tEjemplar; }   
        }

        public static Tabla<string, UsuarioDato> TUsuario
        {
            get { return tUsuario; }
        }

        public static Tabla<string, PrestamoDato> TPrestamo
        {
            get { return tPrestamo;  }
        }
        public static Tabla<string, PersonalBibliotecaDato> TPersonalBiblioteca
        {
            get { return tPersonalBiblioteca; }
        }

        public static Tabla<ClaveEEP, EjemplarEnPrestamoDato> TEEP { 
            get { return tEjemplarEnPrestamo; }
        }
        /// <summary>
        /// Carga en la BD los datos iniciales
        /// </summary>
        public static void LOAD()
        {
            PersonalBibliotecaDato per1 = new PersonalBibliotecaDato("Pepa", "123", "PersonalAdquisiciones");
            PersonalBibliotecaDato per2 = new PersonalBibliotecaDato("Jose", "321", "PersonalSala");
            PersonalBibliotecaDato per3 = new PersonalBibliotecaDato("Eduardo", "456", "PersonalSala");
            
            UsuarioDato u1 = new UsuarioDato("11111111A", "Ana", "Pepa");
            UsuarioDato u2 = new UsuarioDato("22222222B", "Roberto", "Pepa");
            UsuarioDato u3 = new UsuarioDato("33333333C", "Federico", "Pepa");
            UsuarioDato u4 = new UsuarioDato("44444444D", "Eduardo", "Pepa");
           
            LibroDato l1 = new LibroDato("1111", "Viaje al fin de la noche", "Louis-Ferdinand Céline", "Santillán", "Pepa");
            LibroDato l2 = new LibroDato("2222", "Divina comedia", "Dante Alighieri", "Alianza", "Pepa");
            LibroDato l3 = new LibroDato("3333", "Don Quijote de la Mancha", "Miguel de Cervantes", "Cátedra", "Pepa");
            LibroDato l4 = new LibroDato("3355", "1984", "George Orwell", "Planeta", "Pepa");
            LibroDato l5 = new LibroDato("6565", "Hamlet", "William Shakespeare", "Valdemar", "Pepa");
            LibroDato l6 = new LibroDato("7769", "Viaje al centro de la tierra", "Julio Verne", "Urano", "Pepa");
            LibroDato l7 = new LibroDato("7777", "El libro troll", "ElRubiusOMG", "Santillán", "Pepa");
            
            EjemplarDato e1 = new EjemplarDato("e11", EstadoEjemplarEnum.Prestado, "1111", "Pepa");
            EjemplarDato e2 = new EjemplarDato("e12", EstadoEjemplarEnum.Disponible, "1111", "Pepa"); 
            EjemplarDato e3 = new EjemplarDato("e21", EstadoEjemplarEnum.Disponible, "2222", "Pepa"); 
            EjemplarDato e4 = new EjemplarDato("e22", EstadoEjemplarEnum.Prestado, "2222", "Pepa");
            EjemplarDato e5 = new EjemplarDato("e31", EstadoEjemplarEnum.Disponible, "3333", "Pepa");
            EjemplarDato e6 = new EjemplarDato("e32", EstadoEjemplarEnum.Disponible, "3333", "Pepa");
            EjemplarDato e7 = new EjemplarDato("e33", EstadoEjemplarEnum.Prestado, "3333", "Pepa");
            EjemplarDato e8 = new EjemplarDato("e41", EstadoEjemplarEnum.Prestado, "3355", "Pepa");
            EjemplarDato e9 = new EjemplarDato("e42", EstadoEjemplarEnum.Disponible, "3355", "Pepa");
            EjemplarDato e10 = new EjemplarDato("e51", EstadoEjemplarEnum.Prestado, "6565", "Pepa");
            EjemplarDato e11 = new EjemplarDato("e61", EstadoEjemplarEnum.Prestado, "7769", "Pepa");
            EjemplarDato e12 = new EjemplarDato("e62", EstadoEjemplarEnum.Disponible, "7769", "Pepa");
            EjemplarDato e13 = new EjemplarDato("e63", EstadoEjemplarEnum.Disponible, "7769", "Pepa");
            EjemplarDato e14 = new EjemplarDato("e52", EstadoEjemplarEnum.Prestado, "6565", "Pepa");
            EjemplarDato e15 = new EjemplarDato("e71", EstadoEjemplarEnum.Prestado, "7777", "Pepa");
            EjemplarDato e16 = new EjemplarDato("e72", EstadoEjemplarEnum.Prestado, "7777", "Pepa");
            EjemplarDato e17 = new EjemplarDato("e73", EstadoEjemplarEnum.Disponible, "7777", "Pepa");

            PrestamoDato p1 = new PrestamoDato("p1", "11111111A", DateTime.Now, DateTime.Now.AddDays(15), EstadoEnum.EnProceso, "Jose");
            PrestamoDato p2 = new PrestamoDato("p2", "33333333C", DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-5), EstadoEnum.EnProceso, "Jose");
            PrestamoDato p3 = new PrestamoDato("p3", "22222222B", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-15), EstadoEnum.EnProceso, "Jose");
            PrestamoDato p4 = new PrestamoDato("p4", "22222222B", DateTime.Now.AddDays(-45), DateTime.Now.AddDays(-30), EstadoEnum.EnProceso, "Jose");
            PrestamoDato p5 = new PrestamoDato("p5", "11111111A", DateTime.Now, DateTime.Now.AddDays(15), EstadoEnum.Finalizado, "Eduardo");
            PrestamoDato p6 = new PrestamoDato("p6", "33333333C", DateTime.Now.AddDays(-50), DateTime.Now.AddDays(-40), EstadoEnum.Finalizado, "Eduardo");

            EjemplarEnPrestamoDato eep1 = new EjemplarEnPrestamoDato("p1", "e11");
            EjemplarEnPrestamoDato eep2 = new EjemplarEnPrestamoDato("p1", "e22");
            EjemplarEnPrestamoDato eep3 = new EjemplarEnPrestamoDato("p2", "e33");
            EjemplarEnPrestamoDato eep4 = new EjemplarEnPrestamoDato("p2", "e41");
            EjemplarEnPrestamoDato eep5 = new EjemplarEnPrestamoDato("p2", "e51");
            EjemplarEnPrestamoDato eep6 = new EjemplarEnPrestamoDato("p3", "e61");
            EjemplarEnPrestamoDato eep7 = new EjemplarEnPrestamoDato("p4", "e52");
            EjemplarEnPrestamoDato eep8 = new EjemplarEnPrestamoDato("p4", "e71");
            EjemplarEnPrestamoDato eep9 = new EjemplarEnPrestamoDato("p1", "e72");

            BD.DELETE<string, PersonalBibliotecaDato>(per1.Id, "PersonalBibliotecaDato");
            BD.DELETE<string, PersonalBibliotecaDato>(per2.Id, "PersonalBibliotecaDato");
            BD.DELETE<string, PersonalBibliotecaDato>(per3.Id, "PersonalBibliotecaDato");

            BD.DELETE<string, UsuarioDato>(u1.Id, "UsuarioDato");
            BD.DELETE<string, UsuarioDato>(u2.Id, "UsuarioDato");
            BD.DELETE<string, UsuarioDato>(u3.Id, "UsuarioDato");
            BD.DELETE<string, UsuarioDato>(u4.Id, "UsuarioDato");

            BD.DELETE<string, LibroDato>(l1.Isbn, "LibroDato");
            BD.DELETE<string, LibroDato>(l2.Isbn, "LibroDato");
            BD.DELETE<string, LibroDato>(l3.Isbn, "LibroDato");
            BD.DELETE<string, LibroDato>(l4.Isbn, "LibroDato");
            BD.DELETE<string, LibroDato>(l5.Isbn, "LibroDato");
            BD.DELETE<string, LibroDato>(l6.Isbn, "LibroDato");
            BD.DELETE<string, LibroDato>(l7.Isbn, "LibroDato");

            BD.DELETE<string, EjemplarDato>(e1.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e2.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e3.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e4.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e5.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e6.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e7.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e8.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e9.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e10.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e11.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e12.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e13.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e14.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e15.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e16.Codigo, "EjemplarDato");
            BD.DELETE<string, EjemplarDato>(e17.Codigo, "EjemplarDato");

            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep1.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep2.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep3.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep4.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep5.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep6.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep7.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep8.Id, "EjemplarEnPrestamoDato");
            BD.DELETE<ClaveEEP, EjemplarEnPrestamoDato>(eep9.Id, "EjemplarEnPrestamoDato");

            BD.DELETE<string, PrestamoDato>(p1.Codigo, "PrestamoDato");
            BD.DELETE<string, PrestamoDato>(p2.Codigo, "PrestamoDato");
            BD.DELETE<string, PrestamoDato>(p3.Codigo, "PrestamoDato");
            BD.DELETE<string, PrestamoDato>(p4.Codigo, "PrestamoDato");
            BD.DELETE<string, PrestamoDato>(p5.Codigo, "PrestamoDato");
            BD.DELETE<string, PrestamoDato>(p6.Codigo, "PrestamoDato");

            BD.CREATE<string, PersonalBibliotecaDato>(per1);
            BD.CREATE<string, PersonalBibliotecaDato>(per2);
            BD.CREATE<string, PersonalBibliotecaDato>(per3);

            BD.CREATE<string, UsuarioDato>(u1);
            BD.CREATE<string, UsuarioDato>(u2);
            BD.CREATE<string, UsuarioDato>(u3);
            BD.CREATE<string, UsuarioDato>(u4);
            
            BD.CREATE<string, LibroDato>(l1);
            BD.CREATE<string, LibroDato>(l2);
            BD.CREATE<string, LibroDato>(l3);
            BD.CREATE<string, LibroDato>(l4);
            BD.CREATE<string, LibroDato>(l5);
            BD.CREATE<string, LibroDato>(l6);
            BD.CREATE<string, LibroDato>(l7);

            BD.CREATE<string, EjemplarDato>(e1);
            BD.CREATE<string, EjemplarDato>(e2);
            BD.CREATE<string, EjemplarDato>(e3);
            BD.CREATE<string, EjemplarDato>(e4);
            BD.CREATE<string, EjemplarDato>(e5);
            BD.CREATE<string, EjemplarDato>(e6);
            BD.CREATE<string, EjemplarDato>(e7);
            BD.CREATE<string, EjemplarDato>(e8);
            BD.CREATE<string, EjemplarDato>(e9);
            BD.CREATE<string, EjemplarDato>(e10);
            BD.CREATE<string, EjemplarDato>(e11);
            BD.CREATE<string, EjemplarDato>(e12);
            BD.CREATE<string, EjemplarDato>(e13);
            BD.CREATE<string, EjemplarDato>(e14);
            BD.CREATE<string, EjemplarDato>(e15);
            BD.CREATE<string, EjemplarDato>(e16);
            BD.CREATE<string, EjemplarDato>(e17);

            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep1);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep2);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep3);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep4);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep5);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep6);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep7);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep8);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep9);

            BD.CREATE<string, PrestamoDato>(p1);
            BD.CREATE<string, PrestamoDato>(p2);
            BD.CREATE<string, PrestamoDato>(p3);
            BD.CREATE<string, PrestamoDato>(p4);
            BD.CREATE<string, PrestamoDato>(p5);
            BD.CREATE<string, PrestamoDato>(p6);



        }

        /// <summary>
        /// Añade a la BD el elemento pasado por parámetro en la correspondiente tabla
        /// </summary>
        /// <typeparam name="T">Clave de la tabla U</typeparam>
        /// <typeparam name="U">Dato de tipo Tabla con clave T</typeparam>
        /// <param name="u">Elemento a insertar, puede ser nulo</param>
        /// <returns>True si ha podido insertar el elemento en la BD y falso en caso contrario o si el elemento a insertar es nulo</returns>
        public static bool CREATE<T, U>(U u) where U : Entity<T>
        {
            if (u.Equals(null))
            {
                return false;
            }
            else
            if (u is UsuarioDato)
            {

                BD.TUsuario.Add(u as UsuarioDato);
                return true;
            }
            else
            if (u is PrestamoDato)
            {
                BD.TPrestamo.Add(u as PrestamoDato);
                return true;
            }
            else
            if (u is EjemplarDato)
            {

                BD.TEjemplar.Add(u as EjemplarDato);
                return true;
            }
            else
            if (u is LibroDato)
            {

                BD.TLibro.Add(u as LibroDato);
                return true;
            }
            else
            if (u is PersonalBibliotecaDato)
            {

                BD.TPersonalBiblioteca.Add(u as PersonalBibliotecaDato);
                return true;
            }//en caso de no funcionar añadir 3 if con los distintos personales
            else if (u is EjemplarEnPrestamoDato)
            {
                BD.tEjemplarEnPrestamo.Add(u as EjemplarEnPrestamoDato);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Obtiene el elemento de la BD a partir de su clave
        /// </summary>
        /// <typeparam name="T">Clave de la tabla U</typeparam>
        /// <typeparam name="U">Dato de tipo Tabla con clave T</typeparam>
        /// <param name="t">Clave del elemento a buscar</param>
        /// <param name="tabla">Nombre de la tabla en la BD a la que pertenece la tabla</param>
        /// <returns>El elemento en la BD cuya clave se corresponde con la pasada por parámetro</returns>
        public static object READ<T, U>(T t, string tabla) where U : Entity<T>
        {
            if (t.Equals(null)) return null;
            object x = null;
            switch (tabla)
            {
                case "UsuarioDato":
                    if (BD.TUsuario.Contains(t as string)) x = Transformadores.DatoAUsuario(BD.TUsuario[t as string]);
                    break;
                case "PrestamoDato":
                    if (BD.TPrestamo.Contains(t as string)) x = Transformadores.DatoAPrestamo(BD.TPrestamo[t as string]);
                    break;
                case "EjemplarDato":
                    if (BD.TEjemplar.Contains(t as string)) x = Transformadores.DatoAEjemplar(BD.TEjemplar[t as string]);
                    break;
                case "LibroDato":
                    if (BD.TLibro.Contains(t as string)) x = Transformadores.DatoALibro(BD.TLibro[t as string]);
                    break;
                case "PersonalBibliotecaDato":
                    if (BD.TPersonalBiblioteca.Contains(t as string))
                    {
                        PersonalBibliotecaDato personal = BD.TPersonalBiblioteca[t as string];
                        switch (personal.Tipo)
                        {
                            case "PersonalBiblioteca":
                                x = Transformadores.DatoAPersonal(personal);
                                break;
                            case "PersonalAdquisiciones":
                                x = Transformadores.DatoAPersonalAdq(personal);
                                break;
                            case "PersonalSala":
                                x = Transformadores.DatoAPersonalSala(personal);
                                break;
                        }
                        
                    }
                    break;
                /*case "EjemplarEnPrestamoDato":
                    if (BD.TEjemplarEnPrestamo.Contains(t as ClaveEEP)) x = Transformadores.DatoAPersonal(BD.TEjemplarEnPrestamo[t as ClaveEEP]);
                    break;//aca mierdon*/
            }
            return x;
        }
        /// <summary>
        /// Actualiza el elemento pasado por parámetro en la BD
        /// </summary>
        /// <typeparam name="T">Clave de la tabla U</typeparam>
        /// <typeparam name="U">Dato de tipo Tabla con clave T</typeparam>
        /// <param name="u">Elemento a insertar, puede ser nulo</param>
        /// <returns>True si se ha podido actualizar correctamente el elemento en la BD y falso en caso contrario o si el elemento a actualizar es nulo</returns>
        public static bool UPDATE<T, U>(U u) where U : Entity<T>
        {
            bool b = false;
            if (u.Equals(null))
            {
                b = false;
            }
            else if (u is UsuarioDato)
            {
                UsuarioDato ud = u as UsuarioDato;
                if ((BD.READ<string, UsuarioDato>(ud.Dni, "UsuarioDato") != null))
                {
                    BD.DELETE<string, UsuarioDato>(ud.Dni, "UsuarioDato");
                    BD.CREATE<string, UsuarioDato>(ud);
                    b = true;
                }
            }
            else if (u is PrestamoDato) //Comprobar ejemplares con el previo elemento de la tabla
            {
                PrestamoDato ud = u as PrestamoDato;
                if ((BD.READ<string, PrestamoDato>(ud.Codigo, "PrestamoDato") != null))
                {
                    BD.DELETE<string, PrestamoDato>(ud.Codigo, "PrestamoDato");
                    BD.CREATE<string, PrestamoDato>(ud);
                    b = true;
                }
                
            }
            else if (u is EjemplarDato)
            {
                EjemplarDato ud = u as EjemplarDato;
                if ((BD.READ<string, EjemplarDato>(ud.Codigo, "EjemplarDato") != null))
                {
                    BD.DELETE<string, EjemplarDato>(ud.Codigo, "EjemplarDato");
                    BD.CREATE<string, EjemplarDato>(ud);
                    b = true;
                }
            }
            else if (u is LibroDato)
            {
                LibroDato ud = u as LibroDato;
                if ((BD.READ<string, LibroDato>(ud.Isbn, "LibroDato") != null))
                {
                    BD.DELETE<string, LibroDato>(ud.Isbn, "LibroDato");
                    BD.CREATE<string, LibroDato>(ud);
                    b = true;
                }
            }
            else if (u is PersonalBibliotecaDato)
            {
                PersonalBibliotecaDato ud = u as PersonalBibliotecaDato;
                if ((BD.READ<string, PersonalBibliotecaDato>(ud.Id, "PersonalBibliotecaDato") != null))
                {
                    BD.DELETE<string, PersonalBibliotecaDato>(ud.Id, "PersonalBibliotecaDato");
                    BD.CREATE<string, PersonalBibliotecaDato>(ud);
                    b = true;
                }
            }
            return b;
        }

        /// <summary>
        /// Elimina un elemento de la BD, si existe, a partir de su clave
        /// </summary>
        /// <typeparam name="T">Clave de la tabla U</typeparam>
        /// <typeparam name="U">Dato de tipo Tabla con clave T</typeparam>
        /// <param name="t">Clave del elemento a buscar</param>
        /// <param name="tabla">Nombre de la tabla en la BD a la que pertenece la tabla</param>
        /// <returns>True si se ha podido borrar el elemento en la BD con el que se corresponde la clave o falso en caso contrario</returns>
        public static bool DELETE<T, U>(T t, string tabla) where U : Entity<T>
        {
            switch (tabla)
            {
                case "UsuarioDato":
                    foreach (PrestamoDato pd in BD.TPrestamo.ToList())
                    {
                        if (pd.Usuario.Equals(t as string))
                        {
                            BD.TPrestamo.Remove(pd.Codigo);
                        }                       
                    }

                    return BD.TUsuario.Remove(t as string);


                case "PrestamoDato":
                    foreach (EjemplarEnPrestamoDato elem in BD.TEEP.ToList())
                    {
                        if (elem.Id.CodPres.Equals(t as string))
                        {
                            BD.TEEP.Remove(elem.Id);
                        }
                    }
                    return BD.TPrestamo.Remove(t as string);
                case "EjemplarDato":
                    string codEj = t as string;
                    Ejemplar e = BD.READ<string, EjemplarDato>(codEj, "EjemplarDato") as Ejemplar;
                        var l = BD.TEEP.ToList().Where((eep) => eep.CodEjemplar.Equals(codEj));
                        List<EjemplarEnPrestamoDato> listEEP = new List<EjemplarEnPrestamoDato>(l); //EEPs del ejemplar
                        foreach (EjemplarEnPrestamoDato eep in listEEP)
                        {
                            BD.TEEP.Remove(eep.Id);
                        }
                        return BD.TEjemplar.Remove(codEj); 
                case "LibroDato":
                    var b = BD.TEjemplar.ToList().Exists((ej) => ej.Libro.Equals(t as string) && ej.Estado.Equals(EstadoEjemplarEnum.Prestado));
                    if (b)
                    {
                        return false;
                    } else
                    {
                        foreach (EjemplarDato ed in BD.TEjemplar.ToList())
                        {
                            if (ed.Libro.Equals(t as string))
                            {
                                BD.DELETE<string, EjemplarDato>(ed.Codigo, "EjemplarDato"); //Para cada libro se eliminaran todos sus ejemplares 
                            }
                        }
                        return BD.TLibro.Remove(t as string);
                    }
                case "PersonalBibliotecaDato":
                    return BD.TPersonalBiblioteca.Remove(t as string);
            }
            return false;




        }
    }
}
