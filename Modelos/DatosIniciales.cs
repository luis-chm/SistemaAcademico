using SistemaAcademico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Modelos
{
    /// <summary>
    /// Clase que maneja los datos iniciales del sistema académico.
    /// </summary>
    public static class DatosIniciales
    {
        /// <summary>
        /// Método para cargar los datos iniciales en el sistema académico.
        /// </summary>
        public static void CargarDatos(ISistemaAcademico sistema)
        {
            CargarEstudiantes(sistema);
            CargarProfesores(sistema);
            CargarCursos(sistema);
            AsignarProfesoresACursos(sistema);
            MatricularEstudiantesEnCursos(sistema);
        }
        /// <summary>
        /// Método para cargar estudiantes iniciales en el sistema.
        /// </summary>
        private static void CargarEstudiantes(ISistemaAcademico sistema)
        {
            var estudiantes = new[]
            {
                new Estudiante("Ana", "García López", "8888-1111", "12345678", "ana.garcia@email.com", "EST001", "Ingeniería en Sistemas"),
                new Estudiante("Carlos", "Rodríguez Mora", "8888-2222", "202340567", "carlos.rodriguez@email.com", "EST002", "Ingeniería Industrial"),
                new Estudiante("María", "Fernández Castro", "8888-3333", "303450678", "maria.fernandez@email.com", "EST003", "Administración de Empresas"),
                new Estudiante("José", "Vargas Solano", "8888-4444", "404560789", "jose.vargas@email.com", "EST004", "Contaduría Pública"),
                new Estudiante("Laura", "Jiménez Rojas", "8888-5555", "505670890", "laura.jimenez@email.com", "EST005", "Ingeniería en Sistemas")
            };

            foreach (var estudiante in estudiantes)
            {
                sistema.RegistrarEstudiante(estudiante);
            }
        }
        /// <summary>
        /// Método para cargar profesores iniciales en el sistema.
        /// </summary>
        private static void CargarProfesores(ISistemaAcademico sistema)
        {
            var profesores = new[]
            {
                new Profesor("Roberto", "Méndez Arias", "2222-1111", "111111111", "roberto.mendez@upi.edu", "Doctor en Ciencias de la Computación"),
                new Profesor("Patricia", "Sánchez Vega", "2222-2222", "222222222", "patricia.sanchez@upi.edu", "Máster en Ingeniería de Software"),
                new Profesor("Miguel", "Torres Herrera", "2222-3333", "333333333", "miguel.torres@upi.edu", "Licenciado en Matemáticas"),
                new Profesor("Carmen", "López Navarro", "2222-4444", "444444444", "carmen.lopez@upi.edu", "Máster en Administración"),
                new Profesor("Fernando", "Castro Monge", "2222-5555", "555555555", "fernando.castro@upi.edu", "Doctor en Ingeniería Industrial")
            };

            foreach (var profesor in profesores)
            {
                sistema.RegistrarProfesor(profesor);
            }
        }
        /// <summary>
        /// Método para cargar cursos iniciales en el sistema.
        /// </summary>
        private static void CargarCursos(ISistemaAcademico sistema)
        {
            var cursos = new[]
            {
                new Curso("Técnicas de Programación", "PROG101", "Lunes y Miércoles 2:00-4:00 PM"),
                new Curso("Estructura de Datos", "PROG201", "Martes y Jueves 10:00-12:00 PM"),
                new Curso("Base de Datos I", "BD101", "Lunes y Viernes 8:00-10:00 AM"),
                new Curso("Matemáticas Discretas", "MAT201", "Martes y Jueves 2:00-4:00 PM"),
                new Curso("Gestión de Proyectos", "ADM301", "Miércoles y Viernes 10:00-12:00 PM")
            };

            foreach (var curso in cursos)
            {
                sistema.CrearCurso(curso);
            }
        }
        /// <summary>
        /// Método para asignar profesores a los cursos.
        /// </summary>
        private static void AsignarProfesoresACursos(ISistemaAcademico sistema)
        {
            sistema.AsignarProfesorACurso("PROG101", "111111111");
            sistema.AsignarProfesorACurso("PROG201", "222222222");
            sistema.AsignarProfesorACurso("BD101", "111111111");
            sistema.AsignarProfesorACurso("MAT201", "333333333");
            sistema.AsignarProfesorACurso("ADM301", "444444444");
        }
        /// <summary>
        /// Método para matricular estudiantes en los cursos.
        /// </summary>
        private static void MatricularEstudiantesEnCursos(ISistemaAcademico sistema)
        {
            sistema.MatricularEstudianteEnCurso("PROG101", "101230456");
            sistema.MatricularEstudianteEnCurso("PROG101", "202340567");
            sistema.MatricularEstudianteEnCurso("PROG101", "505670890");

            sistema.MatricularEstudianteEnCurso("PROG201", "101230456");
            sistema.MatricularEstudianteEnCurso("PROG201", "505670890");

            sistema.MatricularEstudianteEnCurso("BD101", "101230456");
            sistema.MatricularEstudianteEnCurso("BD101", "303450678");

            sistema.MatricularEstudianteEnCurso("MAT201", "202340567");
            sistema.MatricularEstudianteEnCurso("MAT201", "404560789");
            sistema.MatricularEstudianteEnCurso("MAT201", "505670890");

            sistema.MatricularEstudianteEnCurso("ADM301", "303450678");
            sistema.MatricularEstudianteEnCurso("ADM301", "404560789");
        }
    }
}
