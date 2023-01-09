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

            PrestamoDato p1 = new PrestamoDato("p1", "11111111A", DateTime.Now, DateTime.Now.AddDays(15), EstadoEnum.EnProceso, "Jose");
            PrestamoDato p2 = new PrestamoDato("p2", "33333333C", DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-5), EstadoEnum.EnProceso, "Jose");
            PrestamoDato p3 = new PrestamoDato("p3", "22222222B", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-15), EstadoEnum.EnProceso, "Jose");
            PrestamoDato p4 = new PrestamoDato("p4", "22222222B", DateTime.Now.AddDays(-45), DateTime.Now.AddDays(-30), EstadoEnum.EnProceso, "Jose");

            EjemplarEnPrestamoDato eep1 = new EjemplarEnPrestamoDato("p1", "e11");
            EjemplarEnPrestamoDato eep2 = new EjemplarEnPrestamoDato("p1", "e22");
            EjemplarEnPrestamoDato eep3 = new EjemplarEnPrestamoDato("p2", "e33");
            EjemplarEnPrestamoDato eep4 = new EjemplarEnPrestamoDato("p2", "e41");
            EjemplarEnPrestamoDato eep5 = new EjemplarEnPrestamoDato("p2", "e51");
            EjemplarEnPrestamoDato eep6 = new EjemplarEnPrestamoDato("p3", "e61");
            EjemplarEnPrestamoDato eep7 = new EjemplarEnPrestamoDato("p4", "e52");


            BD.CREATE<string, PersonalBibliotecaDato>(per1);
            BD.CREATE<string, PersonalBibliotecaDato>(per2);
            
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

            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep1);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep2);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep3);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep4);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep5);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep6);
            BD.CREATE<ClaveEEP, EjemplarEnPrestamoDato>(eep7);

            BD.CREATE<string, PrestamoDato>(p1);
            BD.CREATE<string, PrestamoDato>(p2);
            BD.CREATE<string, PrestamoDato>(p3);
            BD.CREATE<string, PrestamoDato>(p4);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Clave de tabla U</typeparam>
        /// <typeparam name="U">Dato tipo Tabla con clave T</typeparam>
        /// <param name="u"></param>
        /// <returns></returns>
        public static bool CREATE<T, U>(U u) where U : Entity<T>
        {
            if (u == null)
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

        public static object READ<T, U>(T t, string tabla) where U : Entity<T>
        {
            if (t == null) return null;
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

        public static bool UPDATE<T, U>(U u) where U : Entity<T>
        {
            bool b = false;
            if (u == null)
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


        public static bool DELETE<T, U>(T t, string tabla) where U : Entity<T>
        {
            //porfavor
            switch (tabla)
            {
                case "UsuarioDato":
                    foreach (PrestamoDato pd in BD.TPrestamo.ToList())
                    {
                        if (pd.Usuario==t as string)
                        {
                            BD.TPrestamo.Remove(pd.Codigo);
                        }                       
                    }

                    return BD.TUsuario.Remove(t as string);


                case "PrestamoDato":
                    foreach (EjemplarEnPrestamoDato elem in BD.TEEP.ToList())
                    {
                        if (elem.Id.CodPres == t as string)
                        {
                            BD.TEEP.Remove(elem.Id);
                        }
                    }
                    return BD.TPrestamo.Remove(t as string);
                case "EjemplarDato":
                    string codEj = t as string;
                    Ejemplar e = BD.READ<string, EjemplarDato>(codEj, "EjemplarDato") as Ejemplar;
                        var l = BD.TEEP.ToList().Where((eep) => eep.CodEjemplar == codEj);
                        List<EjemplarEnPrestamoDato> listEEP = new List<EjemplarEnPrestamoDato>(l); //EEPs del ejemplar
                        foreach (EjemplarEnPrestamoDato eep in listEEP)
                        {
                            BD.TEEP.Remove(eep.Id);
                        }
                        return BD.TEjemplar.Remove(codEj); 
                case "LibroDato":
                    var b = BD.TEjemplar.ToList().Exists((ej) => ej.Estado == EstadoEjemplarEnum.Prestado);
                    if (b)
                    {
                        return false;
                    } else
                    {
                        foreach (EjemplarDato ed in BD.TEjemplar.ToList())
                        {
                            if (ed.Libro == t as string)
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
